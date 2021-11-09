using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageData", menuName = "ScriptableObjects/DamageData", order = 2)]
public class DamageScriptableObject : ScriptableObject
{
    public float Enemy1Damage;
    public float Enemy2Damage;
    public float Enemy3Damage;
    public float Projectile1Damage;
    public float Projectile2Damage;
    public float Projectile3Damage;
}
