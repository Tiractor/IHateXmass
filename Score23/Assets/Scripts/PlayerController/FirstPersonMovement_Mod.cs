﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FirstPersonMovement_Mod : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
        
    }
    private void Start()
    {
        if (PlayerSpawn.PlaceRef != null)
        {
            transform.position = PlayerSpawn.PlaceRef.transform.position;
        }
    }

    public void Moving()
    {
        IsRunning = canRun && Input.GetKey(runningKey);

        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity = new Vector2(Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
    public void ChangeSpeed()
    {
        speed += 3;
        runSpeed += 3;
        StartCoroutine(EndBuff());
    }
    private IEnumerator EndBuff()
    {
        yield return new WaitForSeconds(10);
        speed -= 3;
        runSpeed -= 3;
    }
}