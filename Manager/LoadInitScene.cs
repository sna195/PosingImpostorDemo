using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInitScene : MonoBehaviour
{
    /// <summary>
    /// �ŏ��Ƀ��[�h�������V�[����SceneInfo���ɂ�����ԍ�
    /// </summary>
    [SerializeField] private int _sceneIndex;

    /// <summary>
    /// ���C���V�[���J�ڂ̏������A�Z�b�g
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
