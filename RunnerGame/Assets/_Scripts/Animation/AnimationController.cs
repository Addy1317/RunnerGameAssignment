using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class AnimationController : MonoBehaviour
    {
        [Header("Animator Components")]
        [SerializeField] internal Animator animator;
        [SerializeField] internal string[] animationStateName;

        private void Start()
        {
            if (animator == null)
            {
                animator = GetComponent<Animator>();
            }
        }

        internal void PlayAnimation(string animationName, float transitionTime)
        {
            if (animator == null) return;

            for (int i = 0; i < animationStateName.Length; i++)
            {
                if (this.animationStateName[i] == animationName)
                {
                    animator.CrossFade(animationStateName[i], transitionTime);
                    return;
                }
            }
            Debug.LogWarning("Animation not found: " + animationStateName);
        }
    }
}
