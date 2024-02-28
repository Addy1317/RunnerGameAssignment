using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class Coin : MonoBehaviour, ICollectable
    {
        [SerializeField] private int pointsToGetWhenCollected = 1;

        public void OnCollected(PlayerController refrenceToPlayer)
        {
            refrenceToPlayer.OnCoinCollected(pointsToGetWhenCollected);
            Destroy(gameObject);
        }
    }
}