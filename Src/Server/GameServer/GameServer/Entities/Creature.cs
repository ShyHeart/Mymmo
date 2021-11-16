﻿using Common.Data;
using GameServer.Core;
using GameServer.Managers;
using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Battle;
using GameServer.Battle;

namespace GameServer.Entities
{
    public class Creature : Entity
    {

        public int Id { get; set; }
        public NCharacterInfo Info;
        public CharacterDefine Define;
        public string Name => this.Info.Name;

        public Attributes Attributes;
        public SkillManager SkillMger;

        public bool IsDeath = false;

        public Creature(CharacterType type, int configId, int level, Vector3Int pos, Vector3Int dir) :
           base(pos, dir)
        {
            this.Define = DataManager.Instance.Characters[configId];

            this.Info = new NCharacterInfo();
            this.Info.Type = type;
            this.Info.Level = level;
            this.Info.ConfigId = configId;
            this.Info.Entity = this.EntityData;
            this.Info.EntityId = this.entityId;
            this.Info.Name = this.Define.Name;
            this.InieSkills();

            this.Attributes = new Attributes();
            this.Attributes.Init(this.Define,this.Info.Level,this.GetEquips(),this.Info.attrDynamic);
            this.Info.attrDynamic = this.Attributes.DynamicAttr;
        }

        private void InieSkills()
        {
            SkillMger = new SkillManager(this);
            this.Info.Skills.AddRange(this.SkillMger.Infos);
        }

        public virtual List<EquipDefine> GetEquips()
        {
            return null;
        }

        internal void Caskill(BattleContext context, int skillId)
        {
            Skill skill = this.SkillMger.GetSkill(skillId);
            context.Result = skill.Cast(context);
        }

        public void DoDamage(NDamageInfo damage)
        {
            this.Attributes.HP -= damage.Damage;
            if (this.Attributes.HP<0)
            {
                this.IsDeath = true;
                damage.WillDead = true;
            }
        }

        public override void Update()
        {
            this.SkillMger.Update();
        }
    }
}
