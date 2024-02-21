using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void loadGameScene() //load the game scene 
    {
        SceneManager.LoadScene(4); 
    }

    public void loadStartScreen() //load the start scene
    {
        SceneManager.LoadScene(3);
    }
}
