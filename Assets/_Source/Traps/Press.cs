using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour, IStateChanger
{
    [SerializeField] private float _timeUp;
    [SerializeField] private float _timeDown;

    [SerializeField] private int _damage;

    [SerializeField] private Transform _bottomTargetPoint;
    [SerializeField] private Transform _upTargetPoint;
    [SerializeField] private Transform _movingPart;

    private void Awake()
    {
        StateManager.Subscribe(this);
        StartCoroutine(DoAction());
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.closingAnimation:
                StopCoroutine(DoAction());
                break;
        }
    }

    private IEnumerator DoAction()
    {
        yield return new WaitForSeconds(_timeUp);
        _movingPart.DOMove(_bottomTargetPoint.position, 0.3f).SetEase(Ease.InOutQuart);

        yield return new WaitForSeconds(_timeDown);
        _movingPart.DOMove(_upTargetPoint.position, 0.3f).SetEase(Ease.InOutQuart);

        yield return StartCoroutine(DoAction());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.transform.GetComponent<PlayerHealth>().GetDamage(_damage);
    }
}
