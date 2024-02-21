using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Sprite[] sprites;
    bool move = false;
    int currentType;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    public AnimationCurve curve;
    float animationTimer;
    float speed = 2;
    GameObject door;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        currentType = Random.Range(0, sprites.Length); //randomizes the ghost through a list of sprites (0 for blue ghost, 1 for red)
        spriteRenderer.sprite = sprites[currentType]; //selecting the right sprite
    }

    private void FixedUpdate()
    {
        if (move)
        {
            Vector2 direction = door.transform.position - transform.position; //calculate the direction between the door and the ghost
            rigidbody.MovePosition(rigidbody.position + direction.normalized * speed * Time.deltaTime); //move the ghost to that position

            animationTimer += 0.4f * Time.deltaTime; //setting time for animation of ghost shrinking
            float interpolate = curve.Evaluate(animationTimer); //Evaluate the curve according to the time
            transform.localScale = Vector3.Lerp(Vector3.one * 3, Vector3.zero, interpolate); //shrink the ghost based on the curve evauluation

            if (direction.magnitude < 0.1) //if the ghost has reached their destination
            {
                Destroy(this.gameObject); //remove the ghost from the scene 
            }
        }

    }

    public int getGhostType() //method gets the current ghost
    {
        return currentType;
    }

    void moveGhost(GameObject door) //method is used to move the ghost 
    {
        move = true; //start moving
        this.door = door; //tells the ghost which door to move too
    }
}
