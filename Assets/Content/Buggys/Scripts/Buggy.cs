using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vehicle
{
    [RequireComponent(typeof(Rigidbody))]
    public class Buggy : MonoBehaviour
    {
        [SerializeField] private float baseSpeed = 100;
        [SerializeField] private float maxSteerAngle = 30;
        
        private List<Wheel> _wheels = new List<Wheel>();
        private float _acceleration;
        private float _handling;
        
        public Rigidbody Rigidbody { get; private set; }
        public Transform Transform { get; private set; }

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Transform = GetComponent<Transform>();

            Wheel[] wheels = GetComponentsInChildren<Wheel>();

            foreach (Wheel wheel in wheels)
            {
                wheel.Init(this);
                _wheels.Add(wheel);
            }
        }

        public void SetInput(float acceleration, float handling)
        {
            _acceleration = acceleration;
            _handling = handling;
        }

        private void FixedUpdate()
        {
            foreach (Wheel wheel in _wheels)
            {
                if (wheel.IsDrive)
                {
                    Rigidbody.AddForceAtPosition(Transform.forward * (_acceleration * baseSpeed), wheel.Transform.position);
                }

                if (wheel.IsSteer)
                {
                    wheel.Transform.localRotation = Quaternion.Euler(Vector3.up * (maxSteerAngle * _handling));
                }
            }
        }
    }
}
