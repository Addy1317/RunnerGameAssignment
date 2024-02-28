using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EdgeRunner
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Button Reference")]
        [SerializeField] private Button playButton;
        [SerializeField] private Button quitButton;
     
        private void Start()
        {
            playButton.onClick.AddListener(OnPlayPressed);
            quitButton.onClick.AddListener(OnQuitPressed);
        }

        public void OnPlayPressed()
        {
            LevelLoader.Instance.LoadNextLevel();
        }

        public void OnQuitPressed()
        {
            LevelLoader.Instance.QuitGame();
        }
    }
}