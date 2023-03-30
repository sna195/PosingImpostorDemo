using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseShutter : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] Transform _goal;


    void Awake()
    {
        _transform = transform;
    }

    public void OnRaise()
    {
        _transform.DOMove(_goal.position, 3f);
    }
}
