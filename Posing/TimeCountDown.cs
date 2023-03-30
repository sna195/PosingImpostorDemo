using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class TimeCountDown : MonoBehaviour
{
    [SerializeField] private float INIT_COUNT = 180f;

    //カウントダウン
    private float _countDown;

    //時間を表示するText型の変数
    [SerializeField] private TextMeshProUGUI _timeText;

    [SerializeField] private UnityEvent _unityEvent;


    private void Awake()
    {
        _countDown = INIT_COUNT;
    }

    private void OnDisable()
    {
        _unityEvent.RemoveAllListeners();
    }

    void Update()
    {
        //時間をカウントダウンする
        _countDown -= Time.deltaTime;

        //時間を表示する
        _timeText.text = _countDown.ToString("f0");

        //countdownが0以下になったとき
        if (_countDown <= 0)
        {
            _timeText.text = "0";

            _unityEvent?.Invoke();

            enabled = false;
        }
    }

    public void OnRemoveEvent()
    {
        _unityEvent.RemoveAllListeners();
    }
}