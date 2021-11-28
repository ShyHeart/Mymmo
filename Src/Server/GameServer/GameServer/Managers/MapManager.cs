﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Data;
using GameServer.Models;

namespace GameServer.Managers
{
    class MapManager:Singleton<MapManager>
    {
        //将所有地图都改造为副本的形式
        private Dictionary<int, Dictionary<int, Map>> Maps = new Dictionary<int, Dictionary<int, Map>>();

        public void Init()
        {
            foreach (var mapdefine in DataManager.Instance.Maps.Values)
            {
                Log.InfoFormat("MapManager.Init> Map:{0}:{1}", mapdefine.ID, mapdefine.Name);
                int instanceCount = 1;
                if (mapdefine.Type==MapType.Arena)
                {
                    instanceCount = ArenaManager.MaxInstance;
                }
                this.Maps[mapdefine.ID] = new Dictionary<int, Map>();
                for (int i = 0; i < instanceCount; i++)
                {
                    this.Maps[mapdefine.ID][i] = new Map(mapdefine,i);
                }
            }
        }

        public Map this[int key]
        {
            get { return this.Maps[key][0]; }
        }

        internal Map GetInstance(int mapId, int instance)
        {
            return this.Maps[mapId][instance];
        }

        public void Update()
        {
            foreach (var maps in this.Maps.Values)
            {
                foreach (var instance in maps.Values)
                {
                    instance.Update();

                }
            }
        }

    }
}
