using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseOver() //when over the angel
    {
        if(Input.GetMouseButtonDown(0)) //and left mouse click is pressed
        {
            animator.SetTrigger("blush"); //make the angel blush 
        }
    }

}
