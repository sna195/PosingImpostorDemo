using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    [SerializeField] private RotationSpeed _rotationSpeed;

    [SerializeField] private CameraAxis _cameraAxis;


    private Transform _transform;


    private void Awake()
    {
        _transform = transform;
    }

    public void OnRotate()
    {
        float horizontalMouse = Input.GetAxis("Mouse X");
        float verticalMouse = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButton(0))
        {
            ChangeRotation(Quaternion.AngleAxis(_rotationSpeed.Speed * horizontalMouse, Vector3.down));

            ChangeRotation(Quaternion.AngleAxis(_rotationSpeed.Speed * verticalMouse, _cameraAxis.Right));

        }
        else if (Input.GetMouseButton(1))
        {
            ChangeRotation(Quaternion.AngleAxis(_rotationSpeed.Speed * (horizontalMouse + verticalMouse), _cameraAxis.Forward));
        }
    }

    private void ChangeRotation(Quaternion rotation)
    {
        _transform.rotation = rotation * _transform.rotation;
    }
}