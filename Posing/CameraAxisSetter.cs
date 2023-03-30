using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAxisSetter : MonoBehaviour
{
    [SerializeField] private CameraAxis _cameraAxis;

    // Start is called before the first frame update
    void Awake()
    {
        _cameraAxis.Camera = transform;
    }
}
