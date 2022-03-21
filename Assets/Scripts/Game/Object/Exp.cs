using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS
{
    public class Exp : MonoBehaviour
    {
        [SerializeField] private GameObject _ExpPrefab;
        private void OnCollisionEnter2D(Collision2D col)
        {
            Instantiate(_ExpPrefab, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
