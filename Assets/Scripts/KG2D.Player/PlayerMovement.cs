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
        //private bool isMoving;

        private Vector2 moveDirection;

        private float speed = 5f;
        private float jumpSpeed = 5f;
        private float timeSinceAttack=0f;

        private int currentAttack=0;

        private Rigidbody2D playerRB;
        private Animator animator;
        private SpriteRenderer spriteRenderer;
        private BoxCollider2D bodyColider;

        public void InitializeSystem()
        {
            playerRB = gameObject.GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            bodyColider = gameObject.GetComponent<BoxCollider2D>();
        }

        public void Move()
        {                     
                playerRB.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, playerRB.velocity.y);
                FlipSprite();            
        }
        public void Jump()
        {
            isGrouded = IsGrounded();
            if (isGrouded )
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpSpeed);
                animator.SetTrigger("Jump");
                
            }        
        }
        public void Attack()
        {
            if (timeSinceAttack > 0.25f && playerRB.velocity == Vector2.zero)
            {
                
                currentAttack++;

                if (currentAttack > 3)
                {
                    currentAttack = 1;
                }
                if (timeSinceAttack > 1f)
                {
                    currentAttack = 1;
                }

                animator.SetTrigger("Attack" + currentAttack);
                timeSinceAttack = 0f;
                
            }
            

        }
        public void Roll()
        {
            isGrouded = IsGrounded();
            if (isGrouded)
            {               
                animator.SetTrigger("Roll");
                StartCoroutine(RollForSeconds(0.65f));
               
            }
            
        }

        public void UpdateMovement()
        {
            animator.SetFloat("Speed", Mathf.Abs(playerRB.velocity.x));
            animator.SetFloat("VertSpeed", playerRB.velocity.y);
            timeSinceAttack += Time.deltaTime;
            
        }
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);
        }
        private void FlipSprite()
        {
            if (playerRB.velocity.x < 0) spriteRenderer.flipX = true;
            else spriteRenderer.flipX = false;
        }
        private IEnumerator RollForSeconds(float seconds)
        {
            bodyColider.enabled = !bodyColider.enabled;
            speed *= 1.5f;
            if (spriteRenderer.flipX)
            {
                playerRB.velocity = Vector2.left * speed;
            }
            else
            {
                playerRB.velocity = Vector2.right * speed;
            }

            yield return new WaitForSeconds(seconds);

            speed = speed / 1.5f;
            bodyColider.enabled = !bodyColider.enabled;
        }
        
        
    }

}
