using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PISceneManager : MonoBehaviour
{
    [SerializeField] private SceneInfo _sceneInfo;


    [SerializeField] private string _loading = "Loading";

    [SerializeField] private GameEvent _loadFadeInEvent;

    [SerializeField] private GameEvent _loadFadeOutEvent;


    public IEnumerator Loading()
    {
        yield return SceneManager.LoadSceneAsync(_loading, LoadSceneMode.Additive);

        _loadFadeInEvent.Raise();
    }

    public IEnumerator NewScene()
    {
        yield return SceneManager.LoadSceneAsync(_sceneInfo.GetNextScene(), LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneInfo.GetNextScene()));

        SceneManager.UnloadSceneAsync(_sceneInfo.CurrentSceneName);

        _loadFadeOutEvent.Raise();
    }

    /// <summary>
    /// メインシーンの切り換え
    /// </summary>
    public void StartChangeScene()
    {
        Debug.Log("<color=red> start change scene </color>");

        StartCoroutine(Loading());
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    public void ChangeScene()
    {
        StartCoroutine(NewScene());
    }

    public void EndChangeScene()
    {   
        SceneManager.UnloadSceneAsync(_loading);
        Resources.UnloadUnusedAssets();

        _sceneInfo.IndexCountUp();
    }


    public void Initialize()
    {
        _sceneInfo.Initialize();

        SceneManager.LoadScene("Manager");
    }
}
