using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class Ball : MonoBehaviour
{
    public GameObject Goal;
    public GameObject KickOff;
    public TextMeshProUGUI text;
    Rigidbody2D rigidbody;
    BoxCollider2D goalBoxCollider;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        goalBoxCollider = Goal.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller.DisplayScore(text);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Controller.score += 1;
        rigidbody.velocity = Vector2.zero;
        rigidbody.MovePosition(KickOff.transform.position);
    }
}
