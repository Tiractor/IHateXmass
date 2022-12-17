using System;
using UnityEngine;

abstract public class AttackType : MonoBehaviour
{
    [Range(0, 100)] public float Damage; // DMG of the gun
    abstract public Unit ReturnTarget(); 
}