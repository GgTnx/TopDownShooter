using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        
        [SerializeField] private Animator _animator;
        [SerializeField] private string _shootName;
        [SerializeField] private string _speedName;
        [SerializeField] private string _deathName;

        private void Update() =>
            PlayMove();

        public void PlayShoot() =>
            _animator.SetTrigger(_shootName);

        private void PlayMove() =>
            _animator.SetFloat(_speedName, _rb.velocity.magnitude);

        public void PlayDeath() =>
            _animator.SetTrigger(_deathName);
    }
}