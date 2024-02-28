using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EdgeRunner
{
    public class GameUIView : MonoBehaviour
    {
        [Header("Buttons")]
        [SerializeField] private Button startButton;
        [SerializeField] private Button optionsButton;
        [SerializeField] private Button backButton;

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public void StartButton()
        {

        }
        public void OptionsButton()
        {

        }

        public void BackButton()
        {

        }

        public void QuitButton()
        {
            Application.Quit();
        }
    }
}