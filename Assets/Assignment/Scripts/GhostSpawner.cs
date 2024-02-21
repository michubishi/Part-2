using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GhostSpawner : MonoBehaviour
{
    public GameObject GhostPrefab;
    public GameObject CurrentGhost;
    float points = 0;

    private void Update()
    {
        if (CurrentGhost == null) //if there is no ghost on the screen
        {
            spawnGhost(); //spawn a ghost
        }

        if(points == -1) //if the points equal -1 (because the starting point is 0)
        {
            gameOver(); //game over
        }
    }

    void spawnGhost() //this method creates a ghost.
    {
        CurrentGhost = Instantiate(GhostPrefab); //set the current ghost to the current prefab
    }

    public int getGhostType()
    {
        return CurrentGhost.GetComponent<Ghost>().getGhostType(); //Gets the current ghost from the Ghost class
    }
    
    void MoveGhost(GameObject door)
    {
        CurrentGhost.SendMessage("moveGhost", door); //tell the ghost to move
    }

    void addPoint() //adds 1 point
    {
        points++;
        Debug.Log(points);
    }

    void removePoint() //removes 1 point
    {
        points--;
        Debug.Log(points);
    }

    void gameOver() //method is called when the player loses
    {
        SceneManager.LoadScene(5); //load the gameover scene
    }
}

