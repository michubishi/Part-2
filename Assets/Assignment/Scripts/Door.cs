using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Door : MonoBehaviour
{
    float points;
    public string doorColour;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(doorColour + " Door colour was clicked");
            //send message to ghost 

            //if the ghost belongs to the blue door
                //add a point
            //if the ghost belogs to the red door
                //add a point
            //if it does not belong
            //subtract a point
        }
    }
}
