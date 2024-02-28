using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class Obstacles : MonoBehaviour, ICollidable
    {
        public void OnCollided(PlayerController playerController)
        {
            playerController.OnCollidedWithObstacle();
        }
    }
}