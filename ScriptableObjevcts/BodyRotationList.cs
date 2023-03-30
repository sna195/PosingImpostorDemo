using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[CreateAssetMenu]
public class BodyRotationList : ScriptableObject, ISerializationCallbackReceiver
{
    private Quaternion[] _bodyRotations = new Quaternion[new RotateParts().RotateCount];


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize() 
    {

    }


    public Quaternion GetRotation(int part)
    {
        return _bodyRotations[part];
    }

    public void ChangeRotation(int part, Quaternion rotation)
    {
        _bodyRotations[part] = rotation * _bodyRotations[part];
    }

    public void ChangeAllRotation(Quaternion[] rotarions)
    {
        Assert.IsTrue(rotarions.Length == _bodyRotations.Length, "not match length");

        for (int i = 0; i < _bodyRotations.Length; i++)
        {
            _bodyRotations[i] = rotarions[i];
        }
    }

    public void ResetAllRotation() 
    {
        for (int i = 0; i < _bodyRotations.Length; i++)
        {
            _bodyRotations[i] = Quaternion.identity;
        }
    }
}
