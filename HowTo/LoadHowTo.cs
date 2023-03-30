using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadHowTo : MonoBehaviour
{

    public void OnLoadHowTo()
    {
        SceneManager.LoadScene("HowTo", LoadSceneMode.Additive);
    }

    public void OnUnloadHowTo()
    {
        SceneManager.UnloadSceneAsync("HowTo");
        Resources.UnloadUnusedAssets();
    }
}
