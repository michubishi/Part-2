using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using JetBrains.Annotations;

public class Door : MonoBehaviour
{
    public string doorColour;
    public GameObject GhostSpawner;
    public GameObject Angel;
    Animator AngelAnimator;

    private void Start()
    {
        AngelAnimator = Angel.GetComponent<Animator>(); //get the animator component of the angel
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) //when left mouse button is clicked
        {
            int ghostType = GhostSpawner.GetComponent<GhostSpawner>().getGhostType(); //refer to what kind of ghost it is
            if (ghostType == 0 && doorColour == "Blue") //if the ghost is blue and the player clicks the blue door
            {
                GhostSpawner.SendMessage("addPoint"); //add a point
                AngelAnimator.SetTrigger("happy"); //change animation of angel to happy
            }

            else if (ghostType == 1 && doorColour == "Red") //if the ghost is red and the player clicks the red door
            {
                GhostSpawner.SendMessage("addPoint"); //add a point
                AngelAnimator.SetTrigger("happy"); //change animation of angel to happy
            }

            else //if the player gets the door wrong
            {
                GhostSpawner.SendMessage("removePoint"); //remove a point
                AngelAnimator.SetTrigger("angry"); //change animation of angel to angry
            }
            GhostSpawner.SendMessage("MoveGhost", this.gameObject); //tell the current ghost to move

        }
        }
    }

