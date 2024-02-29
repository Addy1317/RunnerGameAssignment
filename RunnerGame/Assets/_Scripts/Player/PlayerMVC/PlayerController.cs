using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EdgeRunner
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Attributes")]
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float jumpForce = 5f;

        [Header("Physics Reference")]
        private Rigidbody playerRigidbody;
        
        [Header("Collider Reference")]
        [SerializeField] private CapsuleCollider playerCapsuleCollider;
        [SerializeField] private float normalColliderHeight = 115f;
        [SerializeField] private float slidingColliderHeight = 50f;

        [SerializeField] LanesToMove currentLane = LanesToMove.Center;

        [Header("GroundCheck")]
        [SerializeField] private float groundHeight = -0.15f;

        [Header("Immune Time")]
        [SerializeField] private float immunityTime = 1f;

        [Header("Bool Checks")]
        private bool isJumping = false;
        private bool isImmune = false;

        [Header("Vector check")]
        private Vector3 targetDirection = Vector3.zero;
        private float targetX = 0f;
        private bool isMovingInX = false;

        [Header("Script Reference")]
        private PlayerAnimation playerAnimation;
        private PlayerModel playerModel;

        private void Start()
        {
            LevelManager.Instance.PlayerTransform = transform;
            playerRigidbody = GetComponent<Rigidbody>();
            playerAnimation = GetComponent<PlayerAnimation>();
            playerModel = GetComponent<PlayerModel>();
        }

        private void Update()
        {
            MoveForward();
            ResetDirection();
            if (isJumping)
            {
                ResetIsInAir();
            }
            playerModel.UpdateScoreText(playerModel.DistanceTravelled);
        }
        
        private void MoveForward()
        {
            GetComponent<Rigidbody>().MovePosition(transform.position +
                (movementSpeed * Time.deltaTime * (transform.forward + targetDirection)));
        }

        public void MoveLeft()
        {
            currentLane -= 2;
            if (currentLane < LanesToMove.Left)
            {
                currentLane = LanesToMove.Left;
                return;
            }
            targetDirection = transform.right * -1;
            GetNewPositionToMove();
            Debug.Log(currentLane);
        }

        public void MoveRight()
        {
            currentLane += 2;
            if (currentLane > LanesToMove.Right)
            {
                currentLane = LanesToMove.Right;
                return;
            }
            targetDirection = transform.right;
            GetNewPositionToMove();
            Debug.Log(currentLane);
        }

        void GetNewPositionToMove()
        {
            targetX = LanePositions.Instance.GetLanePosition(currentLane).x;
            isMovingInX = true;
        }

        void ResetDirection()
        {
            if (!isMovingInX)
            {
                return;
            }

            if (targetDirection == (transform.right * -1))
            {
                if (transform.position.x <= targetX)
                {
                    targetDirection = Vector3.zero;
                    isMovingInX = false;
                    transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
                }
            }
            else
            {
                if (transform.position.x >= targetX)
                {
                    targetDirection = Vector3.zero;
                    isMovingInX = false;
                    transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
                }
            }
        }

        public void SlideMovementStart()
        {
            playerCapsuleCollider.height = slidingColliderHeight;
            playerCapsuleCollider.center = new Vector3(0, slidingColliderHeight / 2, 0);
        }

        public void SlideMovementStop()
        {
            playerCapsuleCollider.height = normalColliderHeight;
            playerCapsuleCollider.center = new Vector3(0, normalColliderHeight / 2, 0);
        }

        public void PlayerJump()
        {
            GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        public void StartedJumping()
        {
            isJumping = true;
        }

        public void ResetIsInAir()
        {
            if (transform.position.y <= groundHeight)
            {
                isJumping = false;
                playerAnimation.SetIsInAirBool(false);
            }
        }

        public void OnCoinCollected(int points)
        {
            playerModel.InscreaseCollectedCoins();
            playerModel.UpdateCoinsText(playerModel.CollectedCoins);
        }

        private void OnTriggerEnter(Collider other)
        {
            ICollectable collectable = null;
            ICollidable collidableObstacle = null;

            if (other.TryGetComponent<ICollectable>(out collectable))
            {
                collectable.OnCollected(this);
            }

            if (!isImmune && other.TryGetComponent<ICollidable>(out collidableObstacle))
            {
                collidableObstacle.OnCollided(this);
            }
        }

        public void OnCollidedWithObstacle()
        {
            //playerAnimation.SetGetHitTrigger();
            playerModel.LoseLife();
            playerModel.UpdateLifesText(playerModel.Lifes);
            MakeImune();
        }

        void MakeImune()
        {
            isImmune = true;
            StartCoroutine(ImmunityTimer());
        }

        IEnumerator ImmunityTimer()
        {
            yield return new WaitForSeconds(immunityTime);
            isImmune = false;
        }
    }
}