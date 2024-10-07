using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CircleOfPitchforcks : MonoBehaviour, ISatanAttack
{
    [SerializeField] private List<Transform> _pitchforksPositions;
    [SerializeField] private GameObject _pitchforkPrefab;
    [SerializeField] private Transform _target;

    [SerializeField] private float _showDelay;

    [SerializeField] private float _delayToPitchforks;
    [SerializeField] private float _delayForShoot;
    [SerializeField] private float _delayBetweenShots;

    private List<Transform> _positionToPick;
    private List<Transform> _pitchforks;

    private void Start()
    {
        _pitchforks = new List<Transform>();
        _positionToPick = new List<Transform>();
    }

    private void CallAttack()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        StartCoroutine(ShowSpawn());
        yield return new WaitForSeconds(_delayToPitchforks);
        StartCoroutine(LoadPitchforks());
    }

    private IEnumerator ShowSpawn()
    {
        for (int i = 0; i < _pitchforksPositions.Count; i++)
        {
            _pitchforksPositions[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(_showDelay);
        }
    }

    private IEnumerator LoadPitchforks()
    {
        for (int i = 0; i < _pitchforksPositions.Count; i++)
        {
            Transform pitchfork = Instantiate(_pitchforkPrefab, _pitchforksPositions[i].position, Quaternion.identity, _pitchforksPositions[i]).transform;
            _pitchforks.Add(pitchfork);

            pitchfork.up = _target.position - pitchfork.position;
            pitchfork.DOMove(pitchfork.position - pitchfork.up, 0.3f);
            yield return new WaitForSeconds(_showDelay);
        }

        StartCoroutine(SendPitchforks());
    }

    private IEnumerator SendPitchforks()
    {
        _positionToPick = new List<Transform>(_pitchforksPositions);
        for (int i = 0; i < _pitchforksPositions.Count; i++)
        {
            Debug.Log(i);
            Debug.Log(_pitchforksPositions.Count);
            int a = Random.Range(0, _positionToPick.Count);


            _positionToPick[a].gameObject.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            _positionToPick[a].gameObject.SetActive(true);

            _positionToPick.RemoveAt(a);
            _pitchforks[a].GetComponent<Pitchfork>().ShootPitch();
            _pitchforks[a].parent = null;
            _pitchforks.RemoveAt(a);
            yield return new WaitForSeconds(_delayBetweenShots);
        }

        StartCoroutine(HidePlaces());
    }


    private IEnumerator HidePlaces()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < _pitchforksPositions.Count; i++)
        {
            _pitchforksPositions[i].gameObject.SetActive(false);
            yield return new WaitForSeconds(_showDelay);
        }
    }
}
