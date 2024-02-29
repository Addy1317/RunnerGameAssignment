using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class LevelPlatform : MonoBehaviour
    {
        [SerializeField] private float widthOfAPlatform = 56;
        [SerializeField] private float requiredAdditionalDistance = 7;

        private List<Transform> currentObstacles = new List<Transform>();

        [SerializeField] private ObstacleSetsListScriptableObject ObstacleSetsScriptable;

        public float WidthOfAPlatform
        {
            get
            {
                return widthOfAPlatform;
            }
        }
        public float RequiredAdditionalDistance
        {
            get
            {
                return requiredAdditionalDistance;
            }
        }

        public void MakeObstaclesAndCoins()
        {
            int numberOfObstacles = Random.Range(2, 4);
            Vector3 randomPosition;
            float start = transform.position.z + (-1 * (widthOfAPlatform / 2)) + 10;
            randomPosition.z = Random.Range(start, start + 10);

            for (int i = 0; i < numberOfObstacles; i++)
            {

                randomPosition.x = LanePositions.Instance.GetRandomLane();
                randomPosition.y = 0;
                currentObstacles.Add(Instantiate<Transform>(
                    ObstacleSetsScriptable.obstacleSetsList[Random.Range(0, ObstacleSetsScriptable.obstacleSetsList.Length)],
                    randomPosition, Quaternion.identity, transform));
                randomPosition.z += 15;
            }
        }

        public void RemoveObstaclesAndCoins()
        {
            for (int i = 0; i < currentObstacles.Count; i++)
            {
                Destroy(currentObstacles[i].gameObject);
            }
            currentObstacles.Clear();
        }
    }
}
