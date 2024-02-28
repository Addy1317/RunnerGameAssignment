using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class LevelMover : MonoBehaviour
    {
        [SerializeField] private List<LevelPlatform> levelPlatforms;

        private float requiredMinimumDistanceFromPlayer = 35f;
        //[SerializeField]
        //float widthOfAPlatform = 56;

        private void Awake()
        {
            SetAllPlatformsInbeginning();
        }

        private void Start()
        {
            CalculateRequiredMinimumDistance();
        }

        // Update is called once per frame
        private void Update()
        {
            if (CheckIfCanMovePlatformToFront())
            {
                MoveFirstPlatformToLast();
            }
        }

        private bool CheckIfCanMovePlatformToFront()
        {
            float distance = LevelManager.Instance.PlayerTransform.position.z - levelPlatforms[0].transform.position.z;
            return (distance >= requiredMinimumDistanceFromPlayer);
        }

        private void MoveFirstPlatformToLast()
        {
            levelPlatforms[0].RemoveObstaclesAndCoins();
            Transform firstPlatform = levelPlatforms[0].transform;
            firstPlatform.transform.position = (levelPlatforms[levelPlatforms.Count - 1].transform.position +
                (firstPlatform.forward * levelPlatforms[0].WidthOfAPlatform));
            levelPlatforms[0].MakeObstaclesAndCoins();
            levelPlatforms.RemoveAt(0);
            levelPlatforms.Add(firstPlatform.GetComponent<LevelPlatform>());
            CalculateRequiredMinimumDistance();
        }

        private void CalculateRequiredMinimumDistance()
        {
            requiredMinimumDistanceFromPlayer = ((levelPlatforms[0].WidthOfAPlatform / 2) + levelPlatforms[0].RequiredAdditionalDistance);
        }

        private void SetAllPlatformsInbeginning()
        {
            for (int i = 1; i < levelPlatforms.Count; i++)
            {
                levelPlatforms[i].MakeObstaclesAndCoins();
            }
        }
    }
}