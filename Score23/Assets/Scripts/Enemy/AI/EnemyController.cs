using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Unit), typeof(AttackType)), RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private int _speed = 5;
    [SerializeField] private Unit _player;
    private NavMeshAgent _agent;
    private Unit ControlledChar;
    private AttackType _Attack;

    [SerializeField] private float attackCooldown;
    private float _timer;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
        _agent = GetComponent<NavMeshAgent>();
        ControlledChar = GetComponent<Unit>();
        _Attack = GetComponent<AttackType>();
    }

    private void Attack()
    {
        ControlledChar.Command_Attack();
        _timer = attackCooldown;
    }
    private void FixedUpdate()
    {
        if (ControlledChar._isDead) return;
        transform.LookAt(_player.transform.position);
        _timer -= Time.fixedDeltaTime;
        if ((_player.transform.position - transform.position).magnitude < _Attack.Range)
        {
            if(_timer <= 0) Attack();
            _agent.speed = 0;
        }
        else
        {
            _agent.SetDestination(_player.transform.position);
            _agent.speed = _speed;
        }
    }
}
