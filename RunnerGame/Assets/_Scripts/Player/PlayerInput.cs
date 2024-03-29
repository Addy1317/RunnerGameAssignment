using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("Script Reference")]
        private PlayerAnimation playerAnimations;
        private PlayerController playerController;

        [Header("Input Attributes")]
        private float horizontalInput;
        private float verticalInput;

        private void Start()
        {
            playerAnimations = GetComponent<PlayerAnimation>();
            playerController = GetComponent<PlayerController>();
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
                horizontalInput = Input.GetAxisRaw("Horizontal");
             
              
                if (horizontalInput > 0)
                {
                    playerController.MoveRight();
                    OnRightPressed();
                }
                else if (horizontalInput < 0)
                {
                    playerController.MoveLeft();
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