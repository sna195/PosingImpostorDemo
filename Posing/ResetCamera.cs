using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResetCamera : PIButton
{
    [SerializeField] private Transform _cameraTransform;
    private Quaternion _initRotation;


    protected override void Awake()
    {
        base.Awake();

        _initRotation = _cameraTransform.rotation;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        _cameraTransform.rotation = _initRotation;
    }
}
