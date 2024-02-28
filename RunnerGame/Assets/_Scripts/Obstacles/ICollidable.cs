using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public interface ICollidable 
    {
        public void OnCollided(PlayerController playerController);
    }
}