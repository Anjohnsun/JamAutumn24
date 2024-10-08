using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private GameObject _fireballPrefab;
    private bool _targetIsNear;
    [SerializeField] private float _followSpeed;

    private void Update()
    {
        // transform.position = new Vector2(transform.position.x, _target.position.y);
        transform.position = Vector2.Lerp(transform.position, new Vector3(transform.position.x, _target.position.y), _followSpeed * Time.deltaTime);
        if (_target.position.x < transform.position.x)
            transform.GetComponent<SpriteRenderer>().flipX = false;
        if (_target.position.x > transform.position.x)
            transform.GetComponent<SpriteRenderer>().flipX = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            StartCoroutine(Attack());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            StopAllCoroutines();
    }

    private IEnumerator Attack()
    {
        var fireball = Instantiate(_fireballPrefab, _shootPoint.position, Quaternion.identity);
        fireball.transform.up = transform.GetComponent<SpriteRenderer>().flipX == false ? Vector2.left : Vector2.right;
        fireball.GetComponent<Fireball>().ShootFireball();
        yield return new WaitForSeconds(_shootDelay);

        yield return StartCoroutine(Attack());
    }

}
