using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrencyData", menuName = "ScriptableObjects/CurrencyData", order = 1)]
public class CurrencyScriptableObject : ScriptableObject
{
    public int Tower1Cost;
    public int Tower2Cost;
    public int Tower3Cost;
    public int Enemy1Reward;
    public int Enemy2Reward;
    public int Enemy3Reward;
}
