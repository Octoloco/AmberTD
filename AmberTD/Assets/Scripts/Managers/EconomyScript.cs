using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyScript : MonoBehaviour
{
    public static EconomyScript instance = null;

    [SerializeField]
    private int totalCurrency;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddCurrency(int ammount)
    {
        totalCurrency += ammount;
    }

    public void ReduceCurrency(int ammount)
    {
        totalCurrency -= ammount;
    }

    public bool CanAfford(int ammount)
    {
        if (totalCurrency - ammount >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
