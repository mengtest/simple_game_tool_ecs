﻿using System.Collections;
using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Module
{
    public class GameServer : Module, IUpdateEvent
    {
        public GameServer()
        {
            WorldManager.Instance.UnityEventMgr.Add(this);
        }

        public override bool IsBelong(List<Data.Data> dataList)
        {
            for (var i = 0; i < dataList.Count; ++i)
            {
                var dataType = dataList[i].GetType();
                if (dataType == typeof(GameNetworkData))
                {
                    return true;
                }
            }

            return false;
        }

        public void Update()
        {
        }
    }
}
