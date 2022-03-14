using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private PlayerAnimation _playerAnimation;

        [SerializeField] private float _shootDelay = 0.5f;
        
        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] private Transform _bulletSpawnPointTransform;
        [SerializeField]  private Transform _playerTransform;

        private float _currentDelay;
        private Vector3 up;

        private void Start()
        {
            up = _bulletSpawnPointTransform.up;
            _bulletSpawnPointTransform.up = -up;
        }

        private void Update()
        {
            DecrementTimer(Time.deltaTime);
            RotateEnemy();

            if (Input.GetButtonDown("Fire1") && CanShoot())
                Attack();
                
        }
        private void RotateEnemy()
        {
            Vector3 player = _playerTransform.position;
            player.z = 0;
            Vector3 up = player - transform.position;
            transform.up = -up;
        }

        private void DecrementTimer(float deltaTime) =>
            _currentDelay -= deltaTime;

        private bool CanShoot() =>
            _currentDelay <= 0f;

        private void Attack()
        {
            CreateBullet();
            _playerAnimation.PlayShoot();
            SetDelay();
        }

        private void SetDelay() =>
            _currentDelay = _shootDelay;

        private void CreateBullet() =>
            Instantiate(_bulletPrefab, _bulletSpawnPointTransform.position,  _bulletSpawnPointTransform.rotation);
    }
}