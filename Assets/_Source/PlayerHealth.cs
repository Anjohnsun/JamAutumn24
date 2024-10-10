using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private List<Image> _heartSprites;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _halfHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;
    [SerializeField] public Animator anim;
    [SerializeField] private int _currentHp;
    [SerializeField] private int _maxHp;
    private bool _canGetDamage;

    [SerializeField] private GameplayUI _ui;

    private void Start()
    {
        _canGetDamage = true;
        UpdateHearts(); // Обновляем отображение сердец при старте
    }

    public void GetDamage(int damage)
    {
        if (_canGetDamage)
        {
            Debug.Log("Damaged for " + damage);
            _currentHp -= damage;
            
            // Удаляем сердца за каждые 30 единиц урона
            while (_currentHp <= 0 && _heartSprites.Count > 0)
            {
                RemoveHeart();
                _currentHp += 30; // Корректируем текущий хп
            }

            if (_currentHp <= 0)
                Die();
                anim.SetBool("GgDead", true);
        }
        else
        {
            Debug.Log("not damaged");
            if (damage > 90) Die();
        }

        UpdateHearts();
    }

    public void Heal(int healAmount)
    {
        _currentHp += healAmount;
        if (_currentHp > _maxHp)
            _currentHp = _maxHp;

        UpdateHearts();
    }

    private void RemoveHeart()
    {
        if (_heartSprites.Count > 0)
        {
            Destroy(_heartSprites[_heartSprites.Count - 1].gameObject);
            _heartSprites.RemoveAt(_heartSprites.Count - 1);
        }
    }

    private void UpdateHearts()
    {
        int fullHearts = _currentHp / 30; // Высчитываем полные сердца
        int halfHeart = _currentHp % 30 > 0 ? 1 : 0; // Проверка на половину сердца

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
        Debug.Log("Invincible");
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