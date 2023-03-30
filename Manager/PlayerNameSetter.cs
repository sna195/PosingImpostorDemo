using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameSetter : MonoBehaviour
{
    [SerializeField] PlayerInfo _playerInfo;

    /// <summary>
    /// PlayerInfo.PlayerListのインデックス
    /// -1ならローカルプレイヤー
    /// </summary>
    [SerializeField] int _id;


    private TextMeshProUGUI _tmp;


    private void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        if (_id == -1) 
        {
            _tmp.text = _playerInfo.GetMyName();
        }

        _tmp.text = _playerInfo.GetPlayerFromId(_id).Name;
    }
}
