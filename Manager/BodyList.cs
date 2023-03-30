using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodyList : MonoBehaviour
{
    [SerializeField] private Transform[] _transforms = new Transform[new RotateParts().RotateCount];

    [SerializeField] private PlayerInfo _playerInfo;

    [SerializeField] int _id;

    [SerializeField] private GameEvent _sendBodyEvent;


    private Quaternion[] _initRotations = new Quaternion[new RotateParts().RotateCount];


    private void Awake()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            _initRotations[i] = _transforms[i].rotation;
        }

        Debug.Log("Collect BodyList");
    }

    public void ResetAllRotation()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            _transforms[i].rotation = _initRotations[i];
        }
    }

    public void SetMyRotation()
    {
        _playerInfo.SetMyRotation(_transforms.Select(t => t.rotation.eulerAngles).ToArray());

        _sendBodyEvent.Raise();
    }

    public void SetBodyRotation()
    {
        for (int i = 0; i < _transforms.Length; i++)
        {
            _transforms[i].rotation = Quaternion.Euler(_playerInfo.GetPlayerFromId(_id).Rotations[i]);
        }
    }
}
