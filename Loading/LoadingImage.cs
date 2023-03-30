using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingImage : MonoBehaviour
{
    /// <summary>
    /// シーン遷移間に表示するイメージ
    /// </summary>
    private Image _image;

    /// <summary>
    /// フェードインが完了した際のイベント
    /// </summary>
    [SerializeField] private GameEvent _ChangeSceneEvent;

    /// <summary>
    /// フェードアウトが完了した際のイベント
    /// </summary>
    [SerializeField] private GameEvent _EndChangeSceneEvent;


    private void Awake()
    {
        _image = GetComponent<Image>();

        Color color = _image.color;
        color.a = 0;
        _image.color = color;

        Debug.Log("loading");
    }

    private IEnumerator FadeIn()
    {
        _image.DOFade(endValue: 1.0f, duration: 0.5f);

        yield return new WaitForSeconds(0.6f);

        Debug.Log("<color=white> complete fade in </color>");

        _ChangeSceneEvent.Raise();
    }

    private IEnumerator FadeOut()
    {
        _image.DOFade(endValue: 0f, duration: 0.5f);

        yield return new WaitForSeconds(0.6f);

        Debug.Log("<color=white> complete fade out </color>");

        _EndChangeSceneEvent.Raise();
    }

    /// <summary>
    /// フェードインが完了したら新しいシーンをロードするLoadNewSceneEventを起こす
    /// </summary>
    public void LoadFadeIn()
    {
        Debug.Log("fadein");
        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// フェードアウトが完了したらScene/LoadをアンロードするUnloadLoadSceneEventを起こす
    /// </summary>
    public void UnloadFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}
