using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleBonus : MonoBehaviour
{
    [SerializeField] private float _time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.GetComponent<PlayerHealth>().MakeInvincibleForSeconds(_time);

        gameObject.SetActive(false);
    }
}
