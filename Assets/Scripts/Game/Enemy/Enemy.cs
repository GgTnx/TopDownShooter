using TDS.Game.Player;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private enum State
        {
            None = 0,
            Idle = 1,
            Move = 2,
            Attack = 3,
            Death = 4,
            Patrol = 5,
        }

        // [SerializeField] private EnemyAnimation _enemyAnimation;
        [SerializeField] private EnemyAttack _enemyAttack;
        [SerializeField] private EnemyMovement _enemyMovement;
        [SerializeField] private MovePatrol _patrol;
        [SerializeField] private EnemyMeleeAttack _meleeAttack;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Collider2D _collider2D;


        [Header("Settings")] [SerializeField] private float _moveRadius = 1f;
        [SerializeField] private float _attackRadius = 0.5f;
        [SerializeField] private float _meleeRadius;
 
        [SerializeField] private State _currentState = State.Patrol;
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = FindObjectOfType<PlayerMovement>().transform;
            _enemyAttack.enabled = false;
            _enemyMovement.enabled = false;
            _meleeAttack.enabled = false;
           
        }

        private void Update()
        {
            if (_currentState == State.Death)
                return;

            float distance = Vector3.Distance(_playerTransform.position, transform.position);
            if (distance > _moveRadius)
            {
                SetState(State.Patrol);
            }
            else if(distance<=_meleeRadius)
            {
                SetState(State.Attack); 
            }
            else if(distance <= _moveRadius)
            {
                SetState(State.Move);
            }

           
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _moveRadius);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRadius);
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _meleeRadius);
        }

        public void Die()
        {
            SetState(State.Death);
        }

        private void SetState(State state)
        {
            if (_currentState == state)
                return;

            _currentState = state;

            switch (_currentState)
            {
                case State.Idle:
                    _enemyMovement.enabled = false;
                    _enemyMovement.Reset();
                    break;
                case State.Move:
                    _meleeAttack.enabled = false;
                    _patrol.enabled = false;
                    _enemyMovement.enabled = true;
                    break;
                case State.Attack:
                    _enemyMovement.enabled = false;
                    _meleeAttack.enabled = true;
                   // _enemyMovement.Reset();
                    //   _enemyAnimation.PlayMove(_rb.velocity.magnitude);
                    break;
                case State.Death:
                    //      _enemyAnimation.PlayDeath();
                    _enemyMovement.enabled = false;
                    _enemyMovement.Reset();
                    _collider2D.enabled = false;
                    break;
                case State.Patrol:
                    _meleeAttack.enabled = false;
                    _patrol.enabled = true;
                    break;
            }
        }

        private void UpdateState(State state)
        {
            switch (state)
            {
                case State.Move:
                    //      _enemyAnimation.PlayMove(_rb.velocity.magnitude);
                    break;
                case State.Attack:
                    _enemyAttack.Attack();
                    break;
            }
        }
    }
}