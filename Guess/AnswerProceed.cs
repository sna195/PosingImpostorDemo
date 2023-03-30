using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerProceed : MonoBehaviour
{
    /// <summary>
    /// �C���|�X�^�[�̗\�z�e�[�}�̈ړ��̍ŏI�ʒu
    /// </summary>
    [SerializeField] private Transform _move;

    /// <summary>
    /// �C���|�X�^�[�̗\�z�e�[�}�̈ړ�����
    /// </summary>
    [SerializeField] private float _timeY = 1.2f;

    /// <summary>
    /// �\�z�e�[�}�ړ���A������\������܂ł̊Ԋu
    /// </summary>
    [SerializeField] private float _timeAnswer = 0.7f;

    /// <summary>
    /// �����\����AGuess�V�[�����I������܂ł̎���
    /// </summary>
    [SerializeField] private float _timeEnd = 2f;


    /// <summary>
    /// ������...�̃e�L�X�g
    /// </summary>
    [SerializeField] private PIActive _answerText;

    /// <summary>
    /// �����̃e�[�}
    /// </summary>
    [SerializeField] private PIActive _answer;

    /// <summary>
    /// �C���|�X�^�[�̗\�z�e�[�}
    /// </summary>
    [SerializeField] private RectTransform _guessedTransform;

    private PIActive _guessed;

    /// <summary>
    /// Guess�V�[�����I������C�x���g
    /// </summary>
    [SerializeField] private GameEvent _endGuessEvent;



    private void Awake()
    {
        _guessed = _guessedTransform.GetComponent<PIActive>();
    }

    /// <summary>
    /// �����̃e�[�}��\�����鉉�o
    /// </summary>
    public void OnAnswer()
    {
        StartCoroutine(ShowAnswer());
    }

    private IEnumerator ShowAnswer()
    {
        yield return new WaitForSeconds(1f);

        _guessed.OnActive();

        yield return new WaitForSeconds(1f);

        _guessedTransform.DOMove(_move.position, _timeY).SetEase(Ease.OutQuad);

        _answerText.OnActive();

        yield return new WaitForSeconds(_timeY + _timeAnswer);

        _answer.OnActive();

        yield return new WaitForSeconds(_timeEnd);

        _endGuessEvent.Raise();
    }
}
