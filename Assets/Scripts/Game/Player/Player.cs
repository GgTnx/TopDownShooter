using System;
using UnityEngine;

namespace TDS.Game.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _playerHealth;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private PlayerAttack _playerAttack;
        [SerializeField] private PlayerAnimation _playerAnimation;


        private void Update()
        {
            
        }

     

        private void Death()
        {
            _playerAnimation.PlayDeath();
            _playerAttack.enabled = false;
            _playerMovement.enabled = false;
        }

        public void TakeDamage(int dmg)
        {
            _playerHealth -= dmg;
        }
    }
}