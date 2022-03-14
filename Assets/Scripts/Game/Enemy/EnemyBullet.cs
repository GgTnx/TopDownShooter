using System.Collections;
using System.Collections.Generic;
using TDS.Game.Object;
using UnityEngine;

namespace TDS.Game.Enemy
{
    public class EnemyBullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;

        private Vector3 _velocity;

        private void Start()
        {
            _velocity = Vector3.up * _speed;

            StartCoroutine(KillBulletByLifeTime());
        }

        private void Update() =>
            Move();
        

        private void Move() =>
            transform.Translate(_velocity * Time.deltaTime);

        private IEnumerator KillBulletByLifeTime()
        {
            yield return new WaitForSeconds(_lifeTime);

            Kill();
        }

        private void Kill() =>
            Destroy(gameObject);

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag(Tags.Enemy))
            {
                Destroy(col.gameObject);
            }
        }
       
    }
}
