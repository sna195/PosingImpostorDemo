using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRoom : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] Transform _move;

    [SerializeField] float _time;

    [SerializeField] GameEvent _backTitleEvent;


    // Start is called before the first frame update
    private IEnumerator Start()
    {
        _transform = transform;

        _transform.DOMove(_move.position, _time);

        yield return new WaitForSeconds(2.5f);

        _backTitleEvent.Raise();
    }
}
