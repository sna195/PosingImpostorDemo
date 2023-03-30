using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThemeSetter : MonoBehaviour
{
    /// <summary>
    /// ジャンル・テーマの情報を持つアセット
    /// </summary>
    [SerializeField] GenreTheme _genreTheme;

    /// <summary>
    /// プレイヤーの情報を持つアセット
    /// インポスターかどうか
    /// </summary>
    [SerializeField] PlayerInfo _playerInfo;

    /// <summary>
    /// trueならインポスターにお題がわからないようにする
    /// </summary>
    [SerializeField] bool _hide = false;

    private void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = (_hide && _playerInfo.GetMyIsImpostor()) ? "?" : _genreTheme.Theme;
    }
}
