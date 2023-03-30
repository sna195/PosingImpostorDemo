using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GuessTheme : MonoBehaviour
{
    /// <summary>
    /// ジャンル・お題の情報を持つアセット
    /// </summary>
    [SerializeField] private GenreTheme _genreTheme;

    /// <summary>
    /// インポスターのお題予想の情報を持つアセット
    /// </summary>
    [SerializeField] private ImpostorGuess _impostorGuess;

    /// <summary>
    /// 他プレイヤーに推測したテーマを送信するイベント
    /// </summary>
    [SerializeField] private GameEvent _sendGuessedTheme;


    private RectTransform _themeTransform;

    [SerializeField] private TextMeshProUGUI _themeText;

    private Vector3 _themeScale;

    /// <summary>
    /// 送受信のためのテーマリストのインデックス
    /// </summary>
    [SerializeField] private int _themeIndex = 0;


    void Awake()
    {
        _themeText.text = _genreTheme.GetThemeFromIndex(_themeIndex);

        _themeTransform = GetComponent<RectTransform>();

        _themeScale = _themeTransform.localScale;
        _themeTransform.localScale = Vector3.zero;
    }

    private void Start()
    {
        _themeTransform.DOScale(_themeScale, 0.24f).SetEase(Ease.OutCubic).SetDelay(0.1f * _themeIndex);
    }

    public void SetGuessIndex()
    {
        _impostorGuess.GuessIndex = _themeIndex;

        _sendGuessedTheme.Raise();
    }
}
