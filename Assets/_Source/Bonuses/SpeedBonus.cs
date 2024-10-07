using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBonus : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private float _speedBonus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.GetComponent<PlayerController>().SpeedUpForSeconds(_time, _speedBonus);

        gameObject.SetActive(false);
    }
}
