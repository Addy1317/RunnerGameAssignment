using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EdgeRunner
{ 
    public class PauseMenu : MonoBehaviour
    {
        [Header("Button Reference")]
        [SerializeField] private Button resumeButton; 
        [SerializeField] private Button quitButton;
        private void Start()
        {
            resumeButton.onClick.AddListener(OnResumePressed);
            quitButton.onClick.AddListener(OnQuitPressed);
        }

        public void OnResumePressed()
        {
            LevelManager.Instance.OnPausePressed();
        }

        public void OnQuitPressed()
        {
            LevelLoader.Instance.QuitGame();
        }
    }
}