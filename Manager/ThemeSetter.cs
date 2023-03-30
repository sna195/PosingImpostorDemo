using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeSetter : MonoBehaviour
{
    /// <summary>
    /// �W�������E�e�[�}�̏������A�Z�b�g
    /// </summary>
    [SerializeField] GenreTheme _genreTheme;

    /// <summary>
    /// �v���C���[�̏������A�Z�b�g
    /// �C���|�X�^�[���ǂ���
    /// </summary>
    [SerializeField] PlayerInfo _playerInfo;

    /// <summary>
    /// true�Ȃ�C���|�X�^�[�ɂ��肪�킩��Ȃ��悤�ɂ���
    /// </summary>
    [SerializeField] bool _hide = false;

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = (_hide && _playerInfo.GetMyIsImpostor()) ? "?" : _genreTheme.Theme;
    }
}
