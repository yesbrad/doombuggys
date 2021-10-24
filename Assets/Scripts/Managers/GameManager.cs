using System;
using Interfaces;
using Player;
using UnityEngine;
using Vehicle;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public PlayerController Player;
        
        private void Start()
        {
            Player = FindObjectOfType<PlayerController>();
            FindObjectOfType<AIBuggyController>().Possess(Player);
        }
    }
}