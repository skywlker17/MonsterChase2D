using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
   

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
        int selectedPlayer=
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GameManager.instance.CharIndex = selectedPlayer;
        
    }
}
