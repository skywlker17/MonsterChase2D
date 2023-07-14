using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] players;
    public static float highScore;
    private float _highScore
    {
        get { return highScore; }
        set
        {
            _highScore = value;
        }
    }

    public int CharIndex;
    private int _charIndex
    { 
        get { return CharIndex; }
        set {
            _charIndex = value;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        highScore = _highScore;
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded-= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if (scene.name=="Gameplay")
        {
            Instantiate(players[CharIndex]);

        }
    }
    private void Update()
    {
        highScore = Mathf.Max(Timer.score, _highScore);
    }
}
