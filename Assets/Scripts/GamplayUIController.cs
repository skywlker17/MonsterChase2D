using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GamplayUIController : MonoBehaviour
{
   public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Timer.timer = 0;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Timer.timer = 0;
    }
   
}
