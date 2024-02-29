using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    [CreateAssetMenu(fileName = "ObstacleSetsList", menuName = "ScriptableObjects/ObstacleSetsList")]
    public class ObstacleSetsListScriptableObject : ScriptableObject
    {
        public Transform[] obstacleSetsList;
    }
}