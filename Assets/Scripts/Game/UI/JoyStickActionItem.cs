﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickActionItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [System.Serializable]
    public struct JoyStickActionInfo
    {
        public Data.JoyStickActionType actionType;
        public Data.JoyStickActionFaceType faceType;
        public KeyStateType keyStateType;
    }

    public JoyStickActionInfo[] ActionInfo;

    public void OnPointerDown(PointerEventData eventData)
    {
        UpdateActionInfo(KeyStateType.Down);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        UpdateActionInfo(KeyStateType.Up);
    }

    void UpdateActionInfo(KeyStateType keyStateType)
    {
        var player = WorldManager.Instance.Player;
        for (var i = 0; i < ActionInfo.Length; i++)
        {
            var actionInfo = ActionInfo[i];
            if (actionInfo.keyStateType == keyStateType)
            {
                var joyStickData = player.GetData<Data.ClientJoyStickData>();
                Module.ActorJoyStick.AddJoyStickActionData(player, joyStickData, actionInfo.actionType, actionInfo.faceType);
            }
        }
    }
}
