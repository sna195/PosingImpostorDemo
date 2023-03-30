using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
    [SerializeField] private PlayerInfo _playerInfo;


    [SerializeField] private GameEvent _startGame;

    [SerializeField] private GameObject _waitPlayer;


    [SerializeField] private TextMeshProUGUI _inputName;


    public void OnJoin()
    {
        Debug.Log("Join");

        _waitPlayer.SetActive(true);

        _playerInfo.Initialize();
        _playerInfo.MyName = (_inputName.text.Length == 1) ? "ÉvÉåÉCÉÑÅ[" : _inputName.text;

        StartCoroutine(WaitAnimation());

        _startGame.Raise();
    }

    private IEnumerator WaitAnimation()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
