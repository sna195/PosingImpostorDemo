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
    /// �V�[���J�ڊԂɕ\������C���[�W
    /// </summary>
    private Image _image;

    /// <summary>
    /// �t�F�[�h�C�������������ۂ̃C�x���g
    /// </summary>
    [SerializeField] private GameEvent _ChangeSceneEvent;

    /// <summary>
    /// �t�F�[�h�A�E�g�����������ۂ̃C�x���g
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
    /// �t�F�[�h�C��������������V�����V�[�������[�h����LoadNewSceneEvent���N����
    /// </summary>
    public void LoadFadeIn()
    {
        Debug.Log("fadein");
        StartCoroutine(FadeIn());
    }

    /// <summary>
    /// �t�F�[�h�A�E�g������������Scene/Load���A�����[�h����UnloadLoadSceneEvent���N����
    /// </summary>
    public void UnloadFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}
