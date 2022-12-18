using UnityEngine;

namespace ExplosiveEnemySpace
{
    public class Player : MonoBehaviour
    {
        private int _hp = 100;
        public void GetDamage(int damage)
        {
            _hp -= damage;
            Debug.Log(_hp);
        }
    }
}
