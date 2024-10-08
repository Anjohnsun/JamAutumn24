using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Press : MonoBehaviour, IStateChanger
{
    [SerializeField] private float _timeUp;      // Время, за которое пресс поднимается
    [SerializeField] private float _delayBeforeDown; // Время, перед тем как пресс начнет опускаться
    [SerializeField] private float _damage;      // Урон от пресса
    [SerializeField] private Transform _bottomTargetPoint;  // Точка, куда опускается пресс
    [SerializeField] private Transform _upTargetPoint;      // Точка, куда поднимается пресс
    [SerializeField] private Transform _movingPart;         // Движущаяся часть пресса

    private void Awake()
    {
        StateManager.Subscribe(this);
        StartCoroutine(DoAction());
    }

    public void ChangeState(State newState)
    {
        if (newState == State.closingAnimation)
        {
            StopCoroutine(DoAction());
        }
    }

    private IEnumerator DoAction()
    {
        // Подождем перед началом движения вниз
        yield return new WaitForSeconds(_delayBeforeDown);

        // Резкое движение вниз
        _movingPart.DOMove(_bottomTargetPoint.position, 0.2f).SetEase(Ease.InBounce); // Резко опускается

        // Ожидаем перед движением вверх
        yield return new WaitForSeconds(0.2f);

        // Медленное движение вверх
        _movingPart.DOMove(_upTargetPoint