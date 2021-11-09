﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using UnityEngine;

namespace Managers
{
    public class BattleManager:Singleton<BattleManager>
    {
        public Creature Target { get; set; }

        public Vector3 Position { get; set; }
    }
}
