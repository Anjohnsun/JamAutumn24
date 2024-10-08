using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMover : MonoBehaviour
{
    [SerializeField] private RectTransform _panel;
    [SerializeField] private RectTransform _centralAnchor;
    [SerializeField] private RectTransform _upAnchor;
    [SerializeField] private RectTransform _bottomAnchor;

    public void ShowPanel()
    {
        _panel.DOMoveY(_centralAnchor.position.y, 0.5f);
    }

    public void HidePanel()
    {
        _panel.DOMoveY(_upAnchor.position.y, 0.5f).OnComplete(()=> _panel.position = _bottomAnchor.position);
    }
}
