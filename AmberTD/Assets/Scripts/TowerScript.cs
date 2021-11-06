using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Initialize(Vector3 newPosition)
    {
        transform.position = newPosition;
        gameObject.SetActive(true);
    }
}
