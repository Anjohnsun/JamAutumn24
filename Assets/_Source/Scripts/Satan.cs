using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satan : MonoBehaviour, IStateChanger
{
    [SerializeField] private float _timeToFirstAttack;
    [SerializeField] private CircleOfPitchforcks _attack1;
    [SerializeField] private ChaoticPitchforks _attack2;
    [SerializeField] private Vector2 _attackTimeRange;

    [SerializeField] private bool _canAttack;

    private void Start()
    {
        StateManager.Subscribe(this);
        StartCoroutine(DoFirstAttack());
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.gameplay:
                _canAttack = true;
                return;
            case State.pause:
                _canAttack = false;
                return;
            case State.closingAnimation:
                _canAttack = false;
                return;
        }
    }

    private IEnumerator DoFirstAttack()
    {
        Debug.Log("First satan attack");
        yield return new WaitForSeconds(_timeToFirstAttack);

        if (_canAttack)
        {
            int a = Random.Range(0, 2);
            if (a == 0)
                _attack1.Attack();
            else
                _attack2.Attack();
        }

        yield return StartCoroutine(RegularAttack());
    }

    private IEnumerator RegularAttack()
    {
        yield return new WaitForSeconds(Random.Range(_attackTimeRange.x, _attackTimeRange.y));

        Debug.Log("Regular satan attack");
        if (_canAttack)
        {
            int a = Random.Range(0, 2);
            if (a == 0)
                _attack1.Attack();
            else
                _attack2.Attack();
        }

        yield return StartCoroutine(RegularAttack());
    }

}
