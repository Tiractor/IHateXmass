using UnityEngine;
using UnityEngine.AI;

namespace ExplosiveEnemySpace
{
    [RequireComponent(typeof(Rigidbody))]
    public class ExplosiveEnemy : MonoBehaviour
    {
        private int _hp = 10;
        [SerializeField]private int _speed = 5;
        [SerializeField]private int _radius = 5;
        [SerializeField]private int _damage = 10;
        [SerializeField] private GameObject _explosionEffect;

        private GameObject _player;
        private Player _playerScript;
        private Rigidbody _rb;
        private NavMeshAgent _agent;
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _playerScript = _player.GetComponent<Player>();

            _rb = GetComponent<Rigidbody>();

            _agent = GetComponent<NavMeshAgent>();
        }
        private void FixedUpdate()
        {
            if ( (_player.transform.position - transform.position).magnitude < _radius)
                Attack();
            else
            {
                _agent.SetDestination(_player.transform.position);
                _agent.speed = _speed;
            }
        }
        private void Attack()
        {
            _playerScript.GetDamage(_damage);

            _explosionEffect.transform.SetParent(null);
            _explosionEffect.SetActive(true);

            GetDamage(int.MaxValue);
        }
        public void GetDamage(int damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}