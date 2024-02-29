using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("Script Reference")]
        private PlayerAnimation playerAnimations;
        //PlayerMovements playerMovements;

        [Header("Input Attributes")]
        private float horizontalInput;
        private float verticalInput;

        private void Start()
        {
            playerAnimations = GetComponent<PlayerAnimation>();
            //playerMovements = GetComponent<PlayerMovements>();
        }

        private void Update()
        {
            TakeHorizontalInput();
            TakeVerticalInput();
            TakePauseInput();
        }

        private void OnJumpPressed()
        {
            //make player jump
            playerAnimations.SetJumpTrigger();
            playerAnimations.SetIsInAirBool(true);
        }

        private void TakeHorizontalInput()
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                horizontalInput = Input.GetAxis("Horizontal");
                Debug.Log(horizontalInput+" : Horizontal Input Received");

                if (horizontalInput > 0)
                {
                    OnRightPressed();
                }
                else if (horizontalInput < 0)
                {
                    OnLeftPressed();
                }
            }
        }

        private void TakeVerticalInput()
        {
            if (Input.GetButtonDown("Vertical"))
            {
                verticalInput = Input.GetAxisRaw("Vertical");

                if (verticalInput > 0)
                {
                    OnJumpPressed();
                }
                else if (verticalInput < 0)
                {
                    OnSlidePressed();
                }
            }
        }

        private void OnSlidePressed()
        {
            //make player slide
            playerAnimations.SetSlideTrigger();
        }

        private void OnLeftPressed()
        {
            //make player move left if can
            playerAnimations.SetLeftTrigger();
        }

        private void OnRightPressed()
        {
            //make player move right if can
            playerAnimations.SetRightTrigger();
        }

        private void TakePauseInput()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                //pause the game
                LevelManager.Instance.OnPausePressed();
            }
        }
    }
}