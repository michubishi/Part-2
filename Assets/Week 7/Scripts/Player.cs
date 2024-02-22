using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Color selectedColor;
    public Color unselectedColor;
    bool isSelected;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Selected(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Controller.SetSelectedPlayer(this);
    }

    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            spriteRenderer.color = selectedColor;
        }

        else
        {
            spriteRenderer.color = unselectedColor;
        }
    }

}
