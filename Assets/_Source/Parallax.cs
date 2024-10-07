using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform _layerObjects1;
    [SerializeField] private float _movementMultiplyer1;
    private Vector2 _startPos1;

    [SerializeField] private Transform _layerObjects2;
    [SerializeField] private float _movementMultiplyer2;
    private Vector2 _startPos2;

    [SerializeField] private Transform _relativeTarget;
    private Vector2 _startPosition;

    void Start()
    {
        _startPosition = _relativeTarget.position;
        _startPos1 = _layerObjects1.position;
        _startPos2 = _layerObjects2.position;
    }


    void Update()
    {
        _layerObjects1.position = _startPos1 + new Vector2((_relativeTarget.position.x - _startPosition.x) * _movementMultiplyer1, 0);
        _layerObjects2.position = _startPos2 + new Vector2((_relativeTarget.position.x - _startPosition.x) * _movementMultiplyer2, 0);
    }
}
