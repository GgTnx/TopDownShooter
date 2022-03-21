using System;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _player;
        [SerializeField] private float _attackRange;
        [SerializeField] private string _shootName;

        private void Start()
        {
          
        }


        private void Update()
        {
           
            
            float distance = Vector3.Distance(_player.position, transform.position);
            Debug.Log($"distance = {distance}");
            if (distance <= _attackRange)
            {
                _animator.SetTrigger(_shootName);
            }
            
                
        }
    }
}