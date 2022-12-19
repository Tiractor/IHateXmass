using UnityEngine;

public class ExplosiveAttack : AttackType
{
    [SerializeField] private GameObject _explosionEffect;
    public override Unit ReturnTarget()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity, transform);
        gameObject.GetComponent<Unit>().ApplyDMG(gameObject.GetComponent<ExplosiveAttack>());
        return GameObject.FindWithTag("Player").GetComponent<Unit>();
    }
}