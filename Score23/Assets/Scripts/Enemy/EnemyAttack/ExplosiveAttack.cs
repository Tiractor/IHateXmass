using UnityEngine;

public class ExplosiveAttack : AttackType
{
    [SerializeField] private GameObject _explosionEffect;
    public override Unit ReturnTarget()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity, transform);
        GameObject.FindWithTag("Player").GetComponent<Unit>().ApplyDMG(gameObject.GetComponent<ExplosiveAttack>());
        return gameObject.GetComponent<Unit>();
    }
    public override Unit[] ReturnTargets()
    {
        return null;
    }
}