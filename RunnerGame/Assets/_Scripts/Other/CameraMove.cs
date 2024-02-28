using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    public class CameraMove : MonoBehaviour
    {
        [SerializeField] private Vector3 offsetPosition;
        [SerializeField] private Vector3 rotation;

        private Transform playerTransform;
        private Vector3 targetPosition;

        private void Start()
        {
            FollowPlayerPosition();
            SetRotaion(rotation);
        }

        private void LateUpdate()
        {
            FollowPlayerPosition();
        }

        private void FollowPlayerPosition()
        {
            if (playerTransform == null)
            {
                playerTransform = LevelManager.Instance.PlayerTransform;
            }

            targetPosition.x = offsetPosition.x;
            targetPosition.y = offsetPosition.y;
            targetPosition.z = playerTransform.position.z + offsetPosition.z;

            transform.position = targetPosition;
        }

        private void SetRotaion(Vector3 eulerRotation)
        {
            transform.rotation = Quaternion.Euler(eulerRotation);
        }
    }
}