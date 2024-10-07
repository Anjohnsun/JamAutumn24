using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private float _moveDelta;
    [SerializeField] private float _delayToHide;

    private bool _canBeTriggered;

    private void Start()
    {
        _canBeTriggered = true;
    }
    public IEnumerator ActivateTrap()
    {
        Debug.Log("activate spikes");
        _canBeTriggered = false;
        transform.DOMove(transform.position + new Vector3(0, _moveDelta) , 0.2f).SetEase(Ease.Flash);

        yield return new WaitForSeconds(_delayToHide);

        transform.DOMove(transform.position - new Vector3(0, _moveDelta), 0.2f).SetEase(Ease.Flash);
        _canBeTriggered = true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.transform.GetComponent<PlayerHealth>().GetDamage(_damage);

    }
}