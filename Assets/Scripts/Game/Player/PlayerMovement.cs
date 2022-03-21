using TDS.Game.Input;
using UnityEngine;

namespace TDS.Game.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        private Camera _camera;
        private StandardInputService _input;

        private void Start()
        {
          _camera = Camera.main;
            _input = new StandardInputService();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        private void Move()
        {
            _rb.velocity = _input.Axis.normalized * _speed;
        }

        private void Rotate()
        {
            Vector3 mousePosition = _input.MousePosition;
            Vector3 worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            worldPoint.z = 0;

            Vector3 up = worldPoint - transform.position;
            transform.up = up;
        }
    }
}