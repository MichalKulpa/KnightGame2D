using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KG2D.Level
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private int lives;
        private bool isDead=false;


        public void GetDamage(int damage)
        {
            lives -= damage;
            isDead = IsDead();
            Die();
        }
        private void Die()
        {
            if (isDead)
            {
                Debug.Log(gameObject.name + " is dead");
            }
        }

        private bool IsDead()
        {
            if (lives <= 0) return true;           
            else return false;
        }
    }

}

