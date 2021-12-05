﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Models;
using Network;

namespace GameServer.Managers
{
    public class StoryManager:Singleton<StoryManager>
    {
        public const int MaxInstance = 100;

        public class StoryMap
        {
            public Queue<int> InstanceIndexes = new Queue<int>();
            public Story[] Storys = new Story[MaxInstance];
        }

        private Dictionary<int, StoryMap> Storys = new Dictionary<int, StoryMap>();

        public void Init()
        {
            foreach (var story in DataManager.Instance.Storys)
            {
                StoryMap map = new StoryMap();
                for (int i = 0; i < MaxInstance; i++)
                {
                    map.InstanceIndexes.Enqueue(i);
                }

                this.Storys[story.Key] = map;
            }
        }

        public Story NewStory(int storyId, NetConnection<NetSession> owner)
        {
            var storyMap = DataManager.Instance.Storys[storyId].MapId;
            var instance = this.Storys[storyId].InstanceIndexes.Dequeue();
            var map = MapManager.Instance.GetInstance(storyMap, instance);
            Story story = new Story(map, storyId, instance, owner);
            this.Storys[storyId].Storys[instance] = story;
            story.PlayerEnter();
            return story;
        }

        internal void Update()
        {

        }

        public Story GetStory(int storyId, int instanceId)
        {
            return this.Storys[storyId].Storys[instanceId];
        }
    }
}
