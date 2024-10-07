using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private List<Image> _heartSprites;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _halfHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;

    [SerializeField] private int _currentHp;
    [SerializeField] private int _maxHp;
    private bool _canGetDamage;

    [SerializeField] private GameplayUI _ui;

    private void Start()
    {
        _canGetDamage = true;
    }
    public void GetDamage(int a)
    {
        if (_canGetDamage)
        {
            Debug.Log("Damaged for " + a);
            _currentHp -= a;
            if (_currentHp <= 0)
                Die();
        }
        else
        {
            Debug.Log("not damaged");
            if (a > 100) Die();
        }
    }

    public void Heal(int a)
    {
        _currentHp += a;
        if (_currentHp > _maxHp)
            _currentHp = _maxHp;
    }

    private void UpdateHearts()
    {
        int fullHearts = _currentHp / 2;
        int halfHeart = _currentHp % 2;

        for (int i = 0; i < _heartSprites.Count; i++)
        {
            if (i < fullHearts)
            {
                _heartSprites[i].sprite = _fullHeartSprite;
            }
            else if (i == fullHearts && halfHeart > 0)
            {
                _heartSprites[i].sprite = _halfHeartSprite;
            }
            else
            {
                _heartSprites[i].sprite = _emptyHeartSprite;
            }
        }
    }

    public void MakeInvincibleForSeconds(float sec)
    {
        Debug.Log("неу€звимость");
        StartCoroutine(MakeInvincible(sec));
    }

    private IEnumerator MakeInvincible(float sec)
    {
        _canGetDamage = false;
        yield return new WaitForSeconds(sec);
        _canGetDamage = true;
    }

    public void Die()
    {
        Debug.Log("Endgame");
        _ui._setLosePanelVisible(true);
        StateManager.ChangeState(State.pause);
    }
}
