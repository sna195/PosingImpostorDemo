using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ScenePosing : MonoBehaviour
{


    public int SendCount { get; set; }


    void Awake()
    {
        SendCount = 0;
    }


    /// <summary>
    /// 送信数をカウントアップし、ロードする関数を受け取った場合実行
    /// </summary>
    public void SendCountUp()
    {
        SendCount++;

        if (SendCount >= GManager.Instance.Players.Count)
        {
            Debug.Log("<color=yellow> SendMyRotations Complete: </color>");
        }
    }
}
