using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PIActive : MonoBehaviour
{
    [SerializeField] private UnityEvent _beforeEvent;

    [SerializeField] private UnityEvent _afterEvent;


    private GameObject _gameObject;

    private RectTransform _transform;

    private Vector3 _initScale;


    private void Awake()
    {
        _gameObject = gameObject;
        _transform = _gameObject.GetComponent<RectTransform>();

        _initScale = transform.localScale;
        _transform.localScale = Vector3.zero;
    }

    private void OnDisable()
    {
        _beforeEvent.RemoveAllListeners();
        _afterEvent.RemoveAllListeners();
    }

    public void OnActive()
    {
        StartCoroutine(ScaleInvoke());
    }

    private IEnumerator ScaleInvoke()
    {
        _beforeEvent?.Invoke();

        _transform.DOScale(_initScale, 0.24f).SetEase(Ease.OutCubic);

        yield return new WaitForSeconds(0.6f);

        _afterEvent?.Invoke();
    }
}
