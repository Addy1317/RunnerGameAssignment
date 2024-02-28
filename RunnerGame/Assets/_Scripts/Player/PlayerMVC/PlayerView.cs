using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class PlayerView : MonoBehaviour
    {
        [Header("RigidBody")]
        [SerializeField] private Rigidbody playerRigidBody;

        [Header("Collider")]
        [SerializeField] private Collider playerCollider;




        private PlayerController playerController;

        public PlayerView()
        {

        }
    }
}