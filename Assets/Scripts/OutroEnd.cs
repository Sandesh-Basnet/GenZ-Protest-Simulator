using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class OutroEnd : MonoBehaviour
{
    private PlayableDirector director;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        director.stopped += OnTimelineFinished;
    }

    void OnTimelineFinished(PlayableDirector pd)
    {
        SceneManager.LoadScene("Menu");
    }
}