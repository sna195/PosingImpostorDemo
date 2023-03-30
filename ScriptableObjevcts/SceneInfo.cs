using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class SceneInfo : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField] private List<string> _scenes = new List<string>()
    {
        "Title",
        "Posing",
        "ShowAndVote",
        "Posing",
        "ShowAndVote",
        "Ending"
    };

    [SerializeField] private int _initCurrentSceneIndex = 0;

    [SerializeField] private int _initRound = 1;


    public int CurrentSceneIndex { get; set; }

    public string CurrentSceneName { get { return _scenes[CurrentSceneIndex]; } }

    public int Round { get; private set; }


    public void OnBeforeSerialize() { }

    public void OnAfterDeserialize()
    {
        CurrentSceneIndex = _initCurrentSceneIndex;
        Round = _initRound;
    }


    public void Initialize()
    {
        CurrentSceneIndex = 0;
        Round = 1;
    }

    public string GetNextScene()
    {
        return _scenes[(CurrentSceneIndex + 1) % _scenes.Count];
    }

    public void IndexCountUp()
    {
        CurrentSceneIndex++;
        CurrentSceneIndex %= _scenes.Count;
    }

    public void RoundCountUp()
    {
        Round++;
    }
}
