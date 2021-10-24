using System;
using UnityEngine;

namespace Vehicle
{
    [RequireComponent(typeof(ConfigurableJoint))]
    public class Wheel : MonoBehaviour
    {
        [SerializeField] private bool isDrive;
        [SerializeField] private bool isSteer;
        [SerializeField] private Transform artContainer;

        public bool IsDrive => isDrive;
        public bool IsSteer => isSteer;
        public Transform Transform { get; private set; }
        public Rigidbody Rigidbody { get; private set; }

        private Buggy _buggy;

        public Wheel Init(Buggy buggy)
        {
            _buggy = buggy;
            Transform = GetComponent<Transform>();
            Rigidbody = GetComponent<Rigidbody>();
            return this;
        }


        private void Update()
        {
            if (artContainer)
            {
                artContainer.transform.position = Transform.position;
                artContainer.transform.rotation = Transform.rotation;
            }
        }

        private void FixedUpdate()
        {
            Vector3 lVel = transform.InverseTransformDirection(Rigidbody.velocity);
            Rigidbody.AddForce(-transform.right * lVel.x , ForceMode.VelocityChange);
        }
    }
}
