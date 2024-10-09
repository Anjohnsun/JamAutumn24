using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IStateChanger
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _gravityMultiplyer;
    [SerializeField] public Animator anim;

    private bool _canMove;
    private bool _canJump;
    private Vector2 _savedVelocity;

    [SerializeField] private LayerMask _floorLayerMask;

    [SerializeField] private Transform _jumpCheck;

    [SerializeField] private Rigidbody2D _rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        StateManager.Subscribe(this);
        _rb.gravityScale = _gravityMultiplyer;
    }

    public void ChangeState(State newState)
    {
        Debug.Log(newState.ToString());
        switch (newState)
        {
            case State.openingAnimation:
                _canMove = false;
                return;
            case State.gameplay:
                _canMove = true;
                return;
            case State.pause:
                _canMove = false;
                return;
            case State.closingAnimation:
                _canMove = false;
                return;
        }
    }


    void Update()
    {
        if (_canMove)
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
                transform.GetComponent<SpriteRenderer>().flipX = true;
                anim.SetFloat("Run", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
            }

            if (Input.GetKey(KeyCode.D))
            {
                _rb.velocity = new Vector2(_speed, _rb.velocity.y);
                transform.GetComponent<SpriteRenderer>().flipX = false;
                anim.SetFloat("Run", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                _rb.velocity = new Vector2(0, _rb.velocity.y);


            if (Physics2D.Raycast(_jumpCheck.position, Vector2.down, 0.05f, _floorLayerMask.value))
                _canJump = true;

            if (Input.GetKeyDown(KeyCode.Space))
                if (_canJump)
                {
                    _rb.AddForce(Vector2.up * _jumpHeight, ForceMode2D.Impulse);
                    _canJump = false;
                    //anim.SetBool("Jump", true);
                }

            if (Physics2D.Raycast(_jumpCheck.position, Vector2.down, 0.05f, _floorLayerMask))
                _canJump = true;
            else
                _canJump = false;
            //anim.SetBool("Jumping", false);
        }

        else
        {
            _rb.velocity = new Vector2();
        }
    }

    public void SpeedUpForSeconds(float sec, float speedBonus)
    {
        StartCoroutine(SpeedUp(sec, speedBonus));
    }

    private IEnumerator SpeedUp(float sec, float speedBonus)
    {
        float startSpeed = _speed;
        _speed = _speed * speedBonus;
        yield return new WaitForSeconds(sec);
        _speed = startSpeed;
    }
}
