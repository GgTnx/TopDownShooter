using System;
using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class MovePatrol : MonoBehaviour
    {
        [SerializeField] private Transform _poin1;
        [SerializeField] private Transform _poin2;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        public bool _checkpoint = true;

        private Transform _playerTransform;

        private void Update()
        {
            if(_checkpoint)
                MovePoint(_poin1);
            else
            {
                MovePoint(_poin2);
            }
        }


        public void Reset() =>
            _rb.velocity = Vector2.zero;

        private Vector3 Direction(Transform poin) =>
            poin.position - transform.position;

        private void Move(Vector3 direction) =>
            _rb.velocity = direction * _speed;

        private void Rotate(Vector3 direction) =>
            transform.up = direction;

        public void MovePoint(Transform point)
        {
            Vector3 direction = Direction(point);
            Move(direction.normalized);
            Rotate(direction);
            float _distance = Vector3.Distance(point.position, transform.position);
            if (_distance <= 3)
                _checkpoint = !_checkpoint;
        }
    }
}