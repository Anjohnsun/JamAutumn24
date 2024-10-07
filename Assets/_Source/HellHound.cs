using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHound : MonoBehaviour, IStateChanger
{
    [SerializeField] private float _speed;
    private bool _canMove;

    private void Start()
    {
        StateManager.Subscribe(this);
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.openingAnimation:
                _canMove = false;
                return;
            case State.gameplay:
                _canMove = true;
                return;
            case State.closingAnimation:
                _canMove = false;
                return;
        }
    }

    private void Update()
    {
        if (_canMove)
        {
            transform.position = transform.position + transform.right * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            collision.transform.GetComponent<PlayerHealth>().GetDamage(1000);
    }
}
