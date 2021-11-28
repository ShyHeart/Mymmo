﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Network;
using SkillBridge.Message;

namespace GameServer.Managers
{
    class ArenaManager:Singleton<ArenaManager>
    {
        public const int ArenaMapId = 5;
        public const int MaxInstance = 100;

        private Queue<int> InstanceIndexes = new Queue<int>();
        //private Dictionary<int, Arena> Arenas = new Dictionary<int, Arena>();

        public void Init()
        {
            //for (int i = 0; i < MaxInstance; i++)
            //{
            //    InstanceIndexes.Enqueue(i);
            //}
        }

        //public Arena NewArena(ArenaInfo info, NetConnection<NetSession> red, NetConnection<NetSession> blue)
        //{
        //    var instance = InstanceIndexes.Dequeue();
        //    var map = MapManager.Instance.GetInstance(ArenaMapId, instance);
        //    Arena arena = new Arena(map, info, red, blue);
        //    this.PlayerEnter();
        //    return arena;
        //}
    }

}
