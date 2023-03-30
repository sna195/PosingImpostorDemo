using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuessedThemeSetter : MonoBehaviour
{
    /// <summary>
    /// ジャンル・テーマの情報を持つアセット
    /// </summary>
    [SerializeField] GenreTheme _genreTheme;

    /// <summary>
    /// インポスターの予想テーマの情報を持つアセット
    /// </summary>
    [SerializeField] ImpostorGuess _impostorGuess;


    public void OnGuessedTheme()
    {
        GetComponent<TextMeshProUGUI>().text = _genreTheme.GetThemeFromIndex(_impostorGuess.GuessIndex);
    }
}
