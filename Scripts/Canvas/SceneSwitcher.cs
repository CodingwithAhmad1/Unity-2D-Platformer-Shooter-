using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void Home_Exit()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void playGame()
    {
        SceneManager.LoadScene("Base");
    }

    public void levelMenu(){
        SceneManager.LoadScene("Levels");
    }


}
