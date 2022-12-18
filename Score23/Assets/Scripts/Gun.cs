using UnityEngine;

public class Gun : AttackType
{
    [SerializeField] private float reloadTime, coolDown; // RLD and CD of the gun
    private float _cdTimer, _reloadingTimer;

    [SerializeField] private int maxAmmoCount;
    private int _currentAmmoCount;
    
    private Camera _fpsCamera;

    [SerializeField] private Animator animator;

    private void Start()
    {
        _currentAmmoCount = maxAmmoCount;
        _fpsCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && IsReady() && !IsReloading())
        {
            Shoot();
        }
    }

    private bool IsReady()
    {
        return _cdTimer <= 0;
    }

    private bool IsReloading()
    {
        return _reloadingTimer > 0;
    }

    private void FixedUpdate()
    {
        _cdTimer -= Time.fixedDeltaTime;
        _reloadingTimer -= Time.fixedDeltaTime;
    }

    private void Shoot()
    {
        animator.Play("Shoot");
        Debug.Log("BANG!");
        _currentAmmoCount--;
        _cdTimer = coolDown;
        ReturnTarget();
        if (_currentAmmoCount <= 0)
        {
            Reloading();
        }
    }

    private void Reloading()
    {
        animator.SetTrigger("Reloading");
        Debug.Log("RELOAD!");
        _currentAmmoCount = maxAmmoCount;
        _reloadingTimer = reloadTime;
    }

    public override Unit ReturnTarget()
    {
        if (!Physics.Raycast(_fpsCamera.transform.position, _fpsCamera.transform.forward, out var hit, Range)) return null;
        var unit = hit.transform.GetComponent<Unit>();
        return unit;
    }
}