using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIInactive : MonoBehaviour
{
    private GameObject _gameObject;

    private RectTransform _transform;


    private void Awake()
    {
        _gameObject = gameObject;
        _transform = _gameObject.GetComponent<RectTransform>();
    }

    public void OnInactive()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        _transform.DOScale(0f, 0.24f).SetEase(Ease.OutCubic);

        yield return new WaitForSeconds(0.25f);

        _gameObject.SetActive(false);
    }
}
