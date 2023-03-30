using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ShowVoteProceed : MonoBehaviour
{
    [SerializeField] private SceneInfo _sceneInfo;

    [SerializeField] private GameObject _timeRound1;
    [SerializeField] private GameObject _timeRound2;

    [SerializeField] GameEvent _setBodyEvent;

    [SerializeField] GameEvent _showBodyEvent;

    [SerializeField] GameEvent _oneRotationEvent;

    [SerializeField] GameEvent _activeVoteButtonEvent;

    [SerializeField] GameEvent _showVotedCountEvent;

    [SerializeField] GameEvent _showRollEvent;

    [SerializeField] GameEvent _startGuessEvent;

    [SerializeField] GameEvent _showWinEvent;

    [SerializeField] GameEvent _startChangeSceneEvent;


    // Start is called before the first frame update
    private IEnumerator Start()
    {
        if (_sceneInfo.Round == 1)
        {
            _timeRound1.SetActive(true);
        } 
        else if (_sceneInfo.Round == 2)
        {
            _timeRound2.SetActive(true);
        }

        _setBodyEvent.Raise();

        yield return new WaitForSeconds(2f);

        _showBodyEvent.Raise();

        yield return new WaitForSeconds(4f);

        _oneRotationEvent.Raise();

        if (_sceneInfo.Round == 2)
        {
            _activeVoteButtonEvent.Raise();
        }
    }

    public void OnShowVoteRoll()
    {
        StartCoroutine(CoroutineVoteRoll());
    }

    private IEnumerator CoroutineVoteRoll()
    {
        yield return new WaitForSeconds(1f);

        _showVotedCountEvent.Raise();

        yield return new WaitForSeconds(2f);

        _showRollEvent.Raise();

        yield return new WaitForSeconds(3f);

        if (true)

        _startGuessEvent.Raise();
    }


    public void OnStartGuessScene()
    {
        StartCoroutine(LoadGuess());
    }

    private IEnumerator LoadGuess()
    {
        yield return SceneManager.LoadSceneAsync("Guess", LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Guess"));
    }

    public void OnEndGuessScene()
    {
        SceneManager.UnloadSceneAsync("Guess");
        Resources.UnloadUnusedAssets();

        SceneManager.SetActiveScene(SceneManager.GetSceneByName("ShowAndVote"));

        StartCoroutine(CoroutineShowWin());
    }

    private IEnumerator CoroutineShowWin()
    {
        yield return new WaitForSeconds(3f);

        _showWinEvent.Raise();

        yield return new WaitForSeconds(5f);

        _startChangeSceneEvent.Raise();
    }
}
