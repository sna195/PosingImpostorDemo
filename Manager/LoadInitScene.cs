using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInitScene : MonoBehaviour
{
    /// <summary>
    /// 最初にロードしたいシーンのSceneInfo内における番号
    /// </summary>
    [SerializeField] private int _sceneIndex;

    /// <summary>
    /// メインシーン遷移の情報を持つアセット
    /// </summary>
    [SerializeField] private SceneInfo _sceneInfo;


    // Start is called before the first frame update
    private IEnumerator Start()
    {
        SceneManager.LoadSceneAsync("Frame", LoadSceneMode.Additive);

        _sceneInfo.CurrentSceneIndex = _sceneIndex;

        yield return SceneManager.LoadSceneAsync(_sceneInfo.CurrentSceneName, LoadSceneMode.Additive);

        SceneManager.SetActiveScene(SceneManager.GetSceneByName(_sceneInfo.CurrentSceneName));
    }
}
