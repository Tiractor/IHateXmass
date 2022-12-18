using UnityEngine;

public class Gun : AttackType
{
     // DMG and RNG of the Gun
    
    [SerializeField] private Camera fpsCamera;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ReturnTarget();
        }
    }

    public override Unit ReturnTarget()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, Range))
        {
            var unit = hit.transform.GetComponent<Unit>();
            return unit;
        }
        return null;
    }
}
