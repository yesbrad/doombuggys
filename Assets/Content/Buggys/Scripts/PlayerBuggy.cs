using System;
using Interfaces;
using Player;
using UnityEngine;

namespace Vehicle
{
    public class PlayerBuggy : MonoBehaviour, IPossess
    {
        [Range(-1,1)] public float debugAcceleration;
        [Range(-1,1)] public float debugHandling;
        
        private Buggy _buggy;

        public void Possess(PlayerController player)
        {
            _buggy = GetComponent<Buggy>();
        }

        private void Update()
        {
            if (_buggy)
            {
                _buggy.SetInput(debugAcceleration, debugHandling);
            }
        }
    }
}