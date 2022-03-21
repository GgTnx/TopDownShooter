using System;
using TDS.Game.Object;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private string _deathAnimation;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _healthDelay = 0.5f;
        [SerializeField] private Rigidbody2D _Rb;
        private float _currentDelay;


        private void Start()
        {
            SetDelay();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
        
            if (col.gameObject.CompareTag(Tags.Enemy) )
            {
                _currentDelay -= 1f;
                if (_currentDelay<=0)
                {
                    _animator.SetTrigger(_deathAnimation);
                    PlayerMovement _movement = GetComponent<PlayerMovement>();
                   // _movement._isAlive = false;

                }
                
            }
            else if(col.gameObject.CompareTag(Tags.Bullet))
            {
                Destroy(col.gameObject);
                _currentDelay -= 1f;
                if (_currentDelay<=0)
                {
                    _animator.SetTrigger(_deathAnimation);
                    PlayerMovement _movement = GetComponent<PlayerMovement>();
                  //  _movement._isAlive = false;

                }
            }
            
           
        }

       

        private void DecrementTimer(float deltaTime)
        {
            _currentDelay -= deltaTime;
        }

        private void SetDelay() =>
            _currentDelay = _healthDelay;
    }
}