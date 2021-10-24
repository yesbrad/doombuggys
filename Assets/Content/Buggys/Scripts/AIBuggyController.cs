using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using Player;
using UnityEngine;
using Vehicle;

public class AIBuggyController : MonoBehaviour, IPossess
{
    [SerializeField] private Transform debugFollowPoint;
    
    private Buggy _buggy;

    public void Possess(PlayerController player)
    {
        _buggy = GetComponent<Buggy>();
    }

    private void Update()
    {
        float turn = 0;

        turn = Vector3.SignedAngle(_buggy.Transform.forward, _buggy.Transform.position - debugFollowPoint.position,
            Vector3.up);

        if (turn > 0.1f)
        {
            _buggy.SetInput(1, -1);
        }else if (turn < -0.1f)
        {
            _buggy.SetInput(1, 1);
        }
    }
}
