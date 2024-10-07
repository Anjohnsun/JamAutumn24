using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePitchforks : MonoBehaviour, ISatanAttack
{
    [SerializeField] private List<Transform> _pitchforkPositions;
    [SerializeField] List<PositionGroup> _positionGroups;
    [SerializeField] List<AttackQueue> _attackVariations;


    void Start()
    {

    }

    public IEnumerator Attack()
    {
        int a = UnityEngine.Random.Range(0, _attackVariations.Count);
        for(int i = 0; i < _attackVariations.Count; i++)
        {

        }
        yield return new WaitForSeconds(0);
    }


    [Serializable]
    private class PositionGroup
    {
        [SerializeField] public List<Transform> Positions;
    }

    [Serializable]
    private class AttackQueue
    {
        [SerializeField] public List<PositionGroup> GroupQueue;
    }
}
