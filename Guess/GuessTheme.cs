using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GuessTheme : MonoBehaviour
{
    /// <summary>
    /// �W�������E����̏������A�Z�b�g
    /// </summary>
    [SerializeField] private GenreTheme _genreTheme;

    /// <summary>
    /// �C���|�X�^�[�̂���\�z�̏������A�Z�b�g
    /// </summary>
    [SerializeField] private ImpostorGuess _impostorGuess;

    /// <summary>
    /// ���v���C���[�ɐ��������e�[�}�𑗐M����C�x���g
    /// </summary>
    [SerializeField] private GameEvent _sendGuessedTheme;


    private RectTransform _themeTransform;

    [SerializeField] private TextMeshProUGUI _themeText;

    private Vector3 _themeScale;

    /// <summary>
    /// ����M�̂��߂̃e�[�}���X�g�̃C���f�b�N�X
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
