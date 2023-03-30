using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PhotonInfo : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] bool _initIsOffline = true;


    public bool IsOffline { get; private set; }

    public int PlayerNum { get; private set; } = 4;


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        IsOffline = _initIsOffline;
        PlayerNum = IsOffline ? 1 : 4;
    }
}
