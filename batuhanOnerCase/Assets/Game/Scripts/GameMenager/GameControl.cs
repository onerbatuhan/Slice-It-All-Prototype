using System;
using Cinemachine;
using Game.Scripts.ItemMenager;
using Game.Scripts.Pattern;
using UnityEngine;

namespace Game.Scripts.GameMenager
{
    public class GameControl : Singleton<GameControl>
    {
        public CinemachineVirtualCamera cineMachine;
        public enum GameStates
        {
            Continues,
            Successful,
            Fail
            
        }

        public GameStates gameStates;

        public void Start()
        {
            cineMachine.Follow = Item.Instance.currentUsedItem.transform;
        }

       
    }
}
