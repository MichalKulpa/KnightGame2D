using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KG2D.Loop;

namespace KG2D.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform groundCheck;
        [SerializeField]
        private float checkRadius;
        [SerializeField]
        private LayerMask groundMask;

        private bool isGrouded;
        private Vector3 moveDirection;
        private float speed = 5f;
        private float jumpSpeed = 8f;
        private Rigidbody2D playerRB;

        public void InitializeSystem()
        {
            playerRB = gameObject.GetComponent<Rigidbody2D>();
        }
         
        public void Move()
        {
            UpdateMoveDirection();
            transform.position += moveDirection * speed * Time.deltaTime;           
        }
        public void Jump()
        {
            isGrouded = IsGrounded();
            if (isGrouded)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpSpeed);
            }
           
        }

        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);
        }
        private void UpdateMoveDirection()
        {
            moveDirection.x = Input.GetAxis("Horizontal");
        }
    }

}
