using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody;
    public float speed = 2;
    float timer = 0;
 

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        direction.x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
        rigidbody.MoveRotation(270);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        Destroy(this.gameObject);
    }
}
