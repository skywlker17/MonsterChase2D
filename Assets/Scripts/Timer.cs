using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timer;
    public GameObject timeText;
    private GameObject player;
    public static float score;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player) {
            timer += Time.deltaTime;
            timeText.GetComponent<Text>().text = timer.ToString();
        }
        else if (!player)
        {
            score = timer;
            timeText.GetComponent<Text>().text="HIGHSCORE = "+GameManager.highScore.ToString();
        }
        
        
    }
}
