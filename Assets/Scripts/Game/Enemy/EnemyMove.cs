using System;
using TDS.Game.Object;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _attackName;
        [SerializeField] private string _speedName;

        private Vector3 _velocity;
        


        private void Start()
        {
            _velocity = Vector3.up * _speed;
        }

        private void Update()
        { 
            MoveEnemy();
            RotateEnemy();
         
        }

        private void OnCollisionStay2D(Collision2D col)
        {
            AttackEnemy();
            _velocity = Vector3.zero;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(Tags.Bullet))
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }

        private void MoveEnemy()
        {
            transform.Translate(-_velocity * Time.deltaTime);
        }

        private void RotateEnemy()
        {
            Vector3 player = _playerTransform.position;
            player.z = 0;
            Vector3 up = player - transform.position;
            transform.up = -up;
        }

        public void AttackEnemy() =>
            _animator.SetTrigger(_attackName);
    }
}