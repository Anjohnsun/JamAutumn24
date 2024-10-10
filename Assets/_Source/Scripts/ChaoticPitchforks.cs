using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaoticPitchforks : MonoBehaviour
{
    [SerializeField] private List<Transform> pitchforksPositions;
    [SerializeField] private GameObject pitchforkPrefab;
    [SerializeField] private int pitchforkCount;
    [SerializeField] private float shootDelay;
    [SerializeField] private Transform target;

    public IEnumerator Attack()
    {
        for (int i = 0; i < pitchforkCount; i++)
        {
            SpawnAndShootPitchfork();
            yield return new WaitForSeconds(shootDelay);
        }
    }

    private void SpawnAndShootPitchfork()
    {
        int positionIndex = Random.Range(0, pitchforksPositions.Count);
        var pitchfork = Instantiate(pitchforkPrefab, pitchforksPositions[positionIndex].position, Quaternion.identity);

        Vector3 direction = (target.position - pitchfork.transform.position).normalized;
        pitchfork.transform.up = direction;
        pitchfork.transform.eulerAngles = new Vector3(0, 0, RoundAngle(Vector2.SignedAngle(Vector2.up, direction)));

        pitchfork.GetComponent<Pitchfork>().ShootPitch();
    }

    private int RoundAngle(float angle)
    {
        angle = NormalizeAngle(angle);
        return Mathf.RoundToInt(angle / 90) * 90;
    }

    private float NormalizeAngle(float angle)
    {
        angle = angle % 360;
        return angle < 0 ? angle + 360 : angle;
    }
}