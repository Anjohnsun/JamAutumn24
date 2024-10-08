using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour, IStateChanger
{
    [SerializeField] private bool _isShooted;
    [SerializeField] private bool _canMove;

    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;

    [SerializeField] private int _damage;

    private void Awake()
    {
        Debug.Log("spawned");
        _isShooted = false;
        _canMove = true;
        StateManager.Subscribe(this);
    }

    void Update()
    {
        if (_isShooted && _canMove)
        {
            transform.position = transform.position + transform.up * Time.deltaTime * _speed;
            _lifeTime -= Time.deltaTime;
            if (_lifeTime < 0)
                Destroy(gameObject);
        }
    }

    public void ShootFireball()
    {
        Debug.Log("shoot");
        _isShooted = true;
    }

    public void ChangeState(State newState)
    {
        switch (newState)
        {
            case State.gameplay:
                _canMove = true;
                return;
            case State.pause:
                _canMove = false;
                return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth;
        if (collision.TryGetComponent(out playerHealth))
        {
            playerHealth.GetDamage(_damage);
        }
    }
}
