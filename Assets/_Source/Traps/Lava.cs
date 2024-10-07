using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth;
        if(collision.TryGetComponent(out playerHealth))
        {
            playerHealth.GetDamage(1000);
        }
    }
}
