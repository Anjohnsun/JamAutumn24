using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    [SerializeField] private SpikeTrap _spikeTrap;
    [SerializeField] private float _spikeDelay;
    [SerializeField] private LayerMask _playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartCoroutine(DelayedSpikeCall());
    }

    private IEnumerator DelayedSpikeCall()
    {
        yield return new WaitForSeconds(_spikeDelay);

        StartCoroutine(_spikeTrap.ActivateTrap());
    }
}
