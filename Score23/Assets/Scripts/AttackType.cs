using System;
using UnityEngine;

abstract public class AttackType : MonoBehaviour
{
    [Range(-100, 100)] public float Damage; // DMG of the Attack
    public float Range; // RangeOfAttack
    abstract public Unit ReturnTarget();
}