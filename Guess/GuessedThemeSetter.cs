using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuessedThemeSetter : MonoBehaviour
{
    /// <summary>
    /// �W�������E�e�[�}�̏������A�Z�b�g
    /// </summary>
    [SerializeField] GenreTheme _genreTheme;

    /// <summary>
    /// �C���|�X�^�[�̗\�z�e�[�}�̏������A�Z�b�g
    /// </summary>
    [SerializeField] ImpostorGuess _impostorGuess;


    public void OnGuessedTheme()
    {
        GetComponent<TextMeshProUGUI>().text = _genreTheme.GetThemeFromIndex(_impostorGuess.GuessIndex);
    }
}
