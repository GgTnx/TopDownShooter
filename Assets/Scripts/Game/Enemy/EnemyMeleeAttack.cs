using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMeleeAttack : MonoBehaviour
    {
        [SerializeField] private Animator _enemyAnimator;
        [SerializeField] private string _attackName;
        [SerializeField] private Rigidbody2D _rb;
        private Transform _playerTransform;
      

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        }

        private void Update()
        {
            _rb.velocity *= Vector2.zero;
          //  Vector3 direction = Direction();
          // Rotate(direction);
           _enemyAnimator.SetTrigger(_attackName);
        }
        private Vector3 Direction() =>
            _playerTransform.position - transform.position;
        private void Rotate(Vector3 direction) =>
            transform.up = direction;
    }
}