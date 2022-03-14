using UnityEngine;

namespace TDS.Game.Enemy
{
    public class Enemy : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
          
            
                Destroy(col.gameObject);
                Destroy(gameObject);
            
        }
    }
}
