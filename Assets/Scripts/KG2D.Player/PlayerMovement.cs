using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KG2D.Loop;

namespace KG2D.Player
{
    public class PlayerMovement : MonoBehaviour
    {

        private Vector3 moveDirection;
        private float speed = 5f;

        public void InitializeSystem()
        {
            
        }
        public void UpdateMoveDirection()
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
        public void Move()
        {
            UpdateMoveDirection();
            transform.position += moveDirection * speed * Time.deltaTime;
            
        }
    }

}
