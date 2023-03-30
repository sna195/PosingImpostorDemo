using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CameraAxis : ScriptableObject, ISerializationCallbackReceiver
{
    public Transform Camera { get; set; }


    public Vector3 Forward { get { return Camera.forward; } }

    public Vector3 Right { get { return Camera.right; } }



    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize() { }
}
