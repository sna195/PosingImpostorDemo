using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToSlide : MonoBehaviour
{
    [SerializeField] private float _time = 1f;

    private Rect _center;
    [SerializeField] private float _centerRectX = 0.1f;
    [SerializeField] private float _centerRectY = 0.1f;
    [SerializeField] private float _centerRectW = 0.8f;
    [SerializeField] private float _centerRectH = 0.8f;

    private Rect _left;
    [SerializeField] private float _leftRectX = 0f;
    [SerializeField] private float _leftRectY = 0.2f;
    [SerializeField] private float _leftRectW = 0.05f;
    [SerializeField] private float _leftRectH = 0.6f;

    private Rect _right;
    [SerializeField] private float _rightRectX = 0.95f;
    [SerializeField] private float _rightRectY = 0.2f;
    [SerializeField] private float _rightRectW = 0.05f;
    [SerializeField] private float _rightRectH = 0.6f;

    private Camera _camera;


    private void Awake()
    {
        _camera = GetComponent<Camera>();

        _center = new Rect(_centerRectX, _centerRectY, _centerRectW, _centerRectH);
        _left = new Rect(_leftRectX, _leftRectY, _leftRectW, _leftRectH);
        _right = new Rect(_rightRectX, _rightRectY, _rightRectW, _rightRectH);
    }

    public void OnCenter()
    {
        DOTween.To(() => _camera.rect, (x) => _camera.rect = x, _center, _time);
    }

    public void OnLeft()
    {
        DOTween.To(() => _camera.rect, (x) => _camera.rect = x, _left, _time);
    }

    public void OnRight()
    {
        DOTween.To(() => _camera.rect, (x) => _camera.rect = x, _right, _time);
    }
}
