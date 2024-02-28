using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class PlayerAnimation : MonoBehaviour
    {
        [Header("Animator")]
        private Animator playerAnimator;

        [Header("String Attributes")]
        [SerializeField] string slidingParameterName; 
        [SerializeField] string jumpParamName;
        [SerializeField] string leftParamName;
        [SerializeField] string rightParamName;
        [SerializeField] string isInAirParamName;
        [SerializeField] string getHitParamName;

        [Header("Int Id Attributes")]
        private int slidingParamId;
        private int jumpParamId;
        private int leftParamId;
        private int rightParamId;
        private int isInAirParamId;
        private int getHitParamId;

        private void Start()
        {
            playerAnimator = GetComponent<Animator>();
            TakeParametersIds();
        }

        private void TakeParametersIds()
        {
            slidingParamId = Animator.StringToHash(slidingParameterName);
            jumpParamId = Animator.StringToHash(jumpParamName);
            leftParamId = Animator.StringToHash(leftParamName);
            rightParamId = Animator.StringToHash(rightParamName);
            isInAirParamId = Animator.StringToHash(isInAirParamName);
            getHitParamId = Animator.StringToHash(getHitParamName);
        }

        public void SetSlideTrigger()
        {
            playerAnimator.SetTrigger(slidingParamId);
        }

        public void SetLeftTrigger()
        {
            playerAnimator.SetTrigger(leftParamId);
        }

        public void SetRightTrigger()
        {
            playerAnimator.SetTrigger(rightParamId);
        }

        public void SetJumpTrigger()
        {
            playerAnimator.SetTrigger(jumpParamId);
        }

        public void SetIsInAirBool(bool value)
        {
            playerAnimator.SetBool(isInAirParamId, value);
        }

        public void SetGetHitTrigger()
        {
            playerAnimator.SetTrigger(getHitParamId);
        }
    }
}