using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoticPitchforks : MonoBehaviour
{
    [SerializeField] private List<Transform> _pitchforksPositions;
    [SerializeField] private GameObject _pitchforkPrefab;
    [SerializeField] private int _pitchforkCount;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Transform _target;

    public IEnumerator Attack()
    {
        for (int i = 0; i < _pitchforkCount; i++)
        {
            int position = UnityEngine.Random.Range(0, _pitchforksPositions.Count);
            var pitchfork = Instantiate(_pitchforkPrefab, _pitchforksPositions[position].position, Quaternion.identity);
            
            pitchfork.transform.up = _target.position - pitchfork.transform.position;

            pitchfork.transform.eulerAngles = new Vector3(0, 0, RoundAngle(pitchfork.transform.eulerAngles.z));
            pitchfork.GetComponent<Pitchfork>().ShootPitch();

            yield return new WaitForSeconds(_shootDelay);
        }
    }

    private int RoundAngle(float angle)
    {
        angle = NormalizeAngle(angle);

        if (angle >= 0 && angle < 90)
            return 45;
        if (angle >= 90 && angle < 180)
            return 135;
        if (angle >= 180 && angle < 270)
            return 225;
        if (angle >= 270 && angle < 360)
            return 315;

        return (int)angle;
    }

    private float NormalizeAngle(float angle)
    {
        if (angle < 0)
            while (angle < 0)
                angle += 360;
        else if (angle >= 360)
            while (angle >= 360)
                angle -= 360;

        return angle;
    }

}
