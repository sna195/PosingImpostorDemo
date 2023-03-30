using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PIWave : MonoBehaviour
{
    [SerializeField] float _scaleOffset = 1.1f;

    private RectTransform _transform;

    private Vector3 _initScale;


    private void Awake()
    {
        _transform = GetComponent<RectTransform>();

        _initScale = transform.localScale;
    }


    public void OnWave()
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence();
        sequence.Append(_transform.DOScale(_initScale * _scaleOffset, 0.5f).SetEase(Ease.InOutQuad))
                .Append(_transform.DOScale(_initScale, 0.5f).SetEase(Ease.InOutQuad))
                .SetLoops(300, LoopType.Restart);
    }
}
