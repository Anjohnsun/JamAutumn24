using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashingPlatform : MonoBehaviour
{
    [SerializeField] private float _lifetime;
    [SerializeField] private float _transparentPercent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer sr = transform.GetComponent<SpriteRenderer>();
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            DOTween.To(() => sr.color.a,
                (x) => sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, x),
                _transparentPercent, 1).OnComplete(() => transform.GetComponent<Collider2D>().enabled = false);
        }
    }
}
