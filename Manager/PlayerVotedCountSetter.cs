using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerVotedCountSetter : MonoBehaviour
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

    public void OnSetVotedCount()
    {
        if (_id == -1)
        {
            _tmp.text = _playerInfo.GetMyVotedCount().ToString();
        }

        _tmp.text = _playerInfo.GetPlayerFromId(_id).VotedCount.ToString();
    }
}
