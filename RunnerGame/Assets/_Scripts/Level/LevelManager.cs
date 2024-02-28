using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class LevelManager : GenericSingleton<LevelManager>
    {
        public Transform PlayerTransform { get; set; }

        [SerializeField] private PauseMenu pauseMenu;

        private PauseMenu createdPause = null;
        private Transform canvas;

        private void Start()
        {
            canvas = FindObjectOfType<Canvas>().transform;
        }

        bool isPaused = false;
        public void OnPausePressed()
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0;
                createdPause = Instantiate<PauseMenu>(pauseMenu, canvas);
            }
            else
            {
                Time.timeScale = 1;
                Destroy(createdPause.gameObject);
            }
        }
    }
}