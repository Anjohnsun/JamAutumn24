using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDeath : MonoBehaviour
{
private void OnTriggerEnter2D(Collider2D other)
{
    // Проверяем, что объект, с которым произошло столкновение, имеет тег "Player"
    if (other.CompareTag("Player"))
    {
        Destroy(gameObject);
    }
}
}
