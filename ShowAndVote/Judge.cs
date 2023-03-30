using DG.Tweening;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class Judge : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの情報（得票数）を持つアセット
    /// </summary>
    [SerializeField] PlayerInfo _playerInfo;

    /// <summary>
    /// ジャンル・テーマの情報を持つアセット
    /// </summary>
    [SerializeField] GenreTheme _genreTheme;

    /// <summary>
    /// インポスターのテーマ予想の情報を持つアセット
    /// </summary>
    [SerializeField] ImpostorGuess _impostorGuess;

    /// <summary>
    /// プレイヤーの番号(0 <= id <= 3)
    /// </summary>
    [SerializeField] int _id;

    /// <summary>
    /// プレイヤー_idが勝利した際に起きる勝利イメージを表示するイベント
    /// </summary>
    [SerializeField] UnityEvent _winEvent;

    /// <summary>
    /// インポスターの得票数が最大かどうか
    /// </summary>
    private bool _isImposorMaxVoted;

    /// <summary>
    /// インポスターがテーマの推測に成功したかどうか
    /// </summary>
    private bool _isSuccessGuess;



    private void OnDisable()
    {
        _winEvent.RemoveAllListeners();
    }

    public void OnJudge()
    {
        Debug.Log("<color=green> Judge </color>");

        _isImposorMaxVoted = _playerInfo.GetIsImpostorMaxVoted();

        _isSuccessGuess = (_genreTheme.Theme == _genreTheme.GetThemeFromIndex(_impostorGuess.GuessIndex));

        if (_playerInfo.GetPlayerFromId(_id).IsImpostor == (!_isImposorMaxVoted || _isSuccessGuess))
        {
            _winEvent?.Invoke();
        }
    }
}
