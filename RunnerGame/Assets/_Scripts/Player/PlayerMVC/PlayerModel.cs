using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EdgeRunner
{
    public class PlayerModel : MonoBehaviour
    {
        [Header("Text Reference")]
        [SerializeField] private TextMeshProUGUI scoreText;  
        [SerializeField] private TextMeshProUGUI coinsText;
        [SerializeField] private TextMeshProUGUI lifesText;

        public int DistanceTravelled { get; private set; }
        public int CollectedCoins { get; private set; }
        public int Lifes { get; private set; }
        public float TimeTaken { get; private set; }

        private float startingZPosition;
        private void Awake()
        {
            startingZPosition = transform.position.z;
            Lifes = 3;
            DistanceTravelled = 0;
            CollectedCoins = 0;

            UpdateScoreText(DistanceTravelled);
            UpdateLifesText(Lifes);
            UpdateCoinsText(CollectedCoins);
        }

        public void CalculateDistance()
        {
            DistanceTravelled = (int)(transform.position.z - startingZPosition);
        }

        private void Update()
        {
            TimeTaken += Time.deltaTime;
            CalculateDistance();
        }

        public void LoseLife()
        {
            Lifes--;
            if (Lifes <= 0)
            {            
                GameManager.Instance.OnGameOver(DistanceTravelled, CollectedCoins, TimeTaken);
                //Debug.Log(TimeTaken);
            }
        }

        public void InscreaseCollectedCoins()
        {
            CollectedCoins++;
        }

        public void UpdateScoreText(int score)
        {
            scoreText.text = "" + score.ToString();
        }

        public void UpdateLifesText(int lifes)
        {
            lifesText.text = "Lives : " + lifes.ToString();
        }

        public void UpdateCoinsText(int collectedCoins)
        {
            coinsText.text = "Coins : " + collectedCoins.ToString();
        }

        public void IncreaseTimeTaken()
        {
            TimeTaken += Time.deltaTime;
        }
    }
}