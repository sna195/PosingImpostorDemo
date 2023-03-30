using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private RotationSpeed _rotationSpeed;

    private Transform _transform;

    private Quaternion _initRotation;

    private void Awake()
    {
        _transform = transform;
        _initRotation = _transform.rotation;
    }

    public void OnRotate()
    {
        float horizontalMouse = Input.GetAxis("Mouse X");

        if (Input.GetMouseButton(0))
        {
            _transform.rotation = Quaternion.AngleAxis(_rotationSpeed.Speed * horizontalMouse, Vector3.up) * _transform.rotation;
        }
    }

    public void Initialized()
    {
        _transform.rotation = _initRotation;
    }
}
