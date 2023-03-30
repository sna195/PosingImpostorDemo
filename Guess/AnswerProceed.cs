using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerProceed : MonoBehaviour
{
    /// <summary>
    /// インポスターの予想テーマの移動の最終位置
    /// </summary>
    [SerializeField] private Transform _move;

    /// <summary>
    /// インポスターの予想テーマの移動時間
    /// </summary>
    [SerializeField] private float _timeY = 1.2f;

    /// <summary>
    /// 予想テーマ移動後、答えを表示するまでの間隔
    /// </summary>
    [SerializeField] private float _timeAnswer = 0.7f;

    /// <summary>
    /// 答え表示後、Guessシーンを終了するまでの時間
    /// </summary>
    [SerializeField] private float _timeEnd = 2f;


    /// <summary>
    /// 正解は...のテキスト
    /// </summary>
    [SerializeField] private PIActive _answerText;

    /// <summary>
    /// 答えのテーマ
    /// </summary>
    [SerializeField] private PIActive _answer;

    /// <summary>
    /// インポスターの予想テーマ
    /// </summary>
    [SerializeField] private RectTransform _guessedTransform;

    private PIActive _guessed;

    /// <summary>
    /// Guessシーンを終了するイベント
    /// </summary>
    [SerializeField] private GameEvent _endGuessEvent;



    private void Awake()
    {
        _guessed = _guessedTransform.GetComponent<PIActive>();
    }

    /// <summary>
    /// 答えのテーマを表示する演出
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
