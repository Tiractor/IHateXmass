using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Unit>();
        _agent = GetComponent<NavMeshAgent>();
        ControlledChar = GetComponent<Unit>();
        _Attack = GetComponent<AttackType>();
    }
    private void FixedUpdate()
    {
        
        if ((_player.transform.position - transform.position).magnitude < _Attack.Range) { 
            ControlledChar.Command_Attack();
        }
        else
        {
            _agent.SetDestination(_player.transform.position);
            _agent.speed = _speed;
        }
    }
}
