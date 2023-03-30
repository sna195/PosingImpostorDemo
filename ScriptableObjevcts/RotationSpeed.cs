using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RotationSpeed : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] float _initSpeed = 8f;


    public float Speed { get; private set; }


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        Speed = _initSpeed;
    }
}
