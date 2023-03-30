using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class TimeCountDown : MonoBehaviour
{
    [SerializeField] private float INIT_COUNT = 180f;

    //�J�E���g�_�E��
    private float _countDown;

    //���Ԃ�\������Text�^�̕ϐ�
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
        //���Ԃ��J�E���g�_�E������
        _countDown -= Time.deltaTime;

        //���Ԃ�\������
        _timeText.text = _countDown.ToString("f0");

        //countdown��0�ȉ��ɂȂ����Ƃ�
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