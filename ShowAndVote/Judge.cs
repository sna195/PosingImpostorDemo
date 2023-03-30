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
    /// �v���C���[�̏��i���[���j�����A�Z�b�g
    /// </summary>
    [SerializeField] PlayerInfo _playerInfo;

    /// <summary>
    /// �W�������E�e�[�}�̏������A�Z�b�g
    /// </summary>
    [SerializeField] GenreTheme _genreTheme;

    /// <summary>
    /// �C���|�X�^�[�̃e�[�}�\�z�̏������A�Z�b�g
    /// </summary>
    [SerializeField] ImpostorGuess _impostorGuess;

    /// <summary>
    /// �v���C���[�̔ԍ�(0 <= id <= 3)
    /// </summary>
    [SerializeField] int _id;

    /// <summary>
    /// �v���C���[_id�����������ۂɋN���鏟���C���[�W��\������C�x���g
    /// </summary>
    [SerializeField] UnityEvent _winEvent;

    /// <summary>
    /// �C���|�X�^�[�̓��[�����ő傩�ǂ���
    /// </summary>
    private bool _isImposorMaxVoted;

    /// <summary>
    /// �C���|�X�^�[���e�[�}�̐����ɐ����������ǂ���
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
