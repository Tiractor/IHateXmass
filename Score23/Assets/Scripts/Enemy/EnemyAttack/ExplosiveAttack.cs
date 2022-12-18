using UnityEngine;

public class ExplosiveAttack : AttackType
{
    [SerializeField] private GameObject _explosionEffect;
    public override Unit ReturnTarget()
    {

        _explosionEffect.transform.SetParent(null);
        _explosionEffect.SetActive(true);
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), transform.forward, out hit, Range))
        {
            var unit = hit.transform.GetComponent<Unit>();
            unit.ApplyDMG(gameObject.GetComponent<ExplosiveAttack>());
        }
        return gameObject.GetComponent<Unit>();
    }
}