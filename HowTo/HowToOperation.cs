using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToOperation : MonoBehaviour
{
    [SerializeField] private float _time = 1.3f; 

    [SerializeField] Transform _body;

    [SerializeField] RectTransform _mouseLeft;
    private Vector2 _initLeft;

    [SerializeField] RectTransform _mouseRight;
    private Vector2 _initRight;

    [SerializeField] RectTransform _leftGoal;
    [SerializeField] RectTransform _leftUpGoal;

    [SerializeField] RectTransform _rightGoal;


    private void Awake()
    {
        _initLeft = _mouseLeft.anchoredPosition;
        _initRight = _mouseRight.anchoredPosition;
    }

    public void Start()
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence();

        sequence.Append(_body.DORotate(new Vector3(0, 180, 0), _time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad))
                .Join(_mouseLeft.DOAnchorPos(_initLeft + _leftGoal.anchoredPosition, _time).SetEase(Ease.InOutQuad))

                .Append(_body.DORotate(new Vector3(0, -90, 0), _time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad))
                .Join(_mouseLeft.DOAnchorPos(_initLeft, _time).SetEase(Ease.InOutQuad))

                .Append(_body.DORotate(new Vector3(90, 0, 0), _time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad))
                .Join(_mouseLeft.DOAnchorPos(_initLeft + _leftUpGoal.anchoredPosition, _time).SetEase(Ease.InOutQuad))

                .Append(_body.DORotate(new Vector3(-180, 0, 0), _time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad))
                .Join(_mouseLeft.DOAnchorPos(_initLeft, _time).SetEase(Ease.InOutQuad))

                .Append(_body.DORotate(new Vector3(0, 0, 180), _time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad))
                .Join(_mouseRight.DOAnchorPos(_initRight + _rightGoal.anchoredPosition, _time).SetEase(Ease.InOutQuad))

                .Append(_body.DORotate(new Vector3(0, 0, -90), _time, RotateMode.WorldAxisAdd).SetEase(Ease.InOutQuad))
                .Join(_mouseRight.DOAnchorPos(_initRight, _time).SetEase(Ease.InOutQuad))

                .SetLoops(100, LoopType.Restart);
    }
}
