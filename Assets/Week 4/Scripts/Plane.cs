using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject runway;
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;

    Vector2 currentPosition;
    Vector2 lastPosition;
   
    LineRenderer lineRenderer;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody;
    BoxCollider2D RWboxcollider;
    Runway RWScript;

    public float speed = 1;
    public AnimationCurve landing;
    float timerValue;

    public Sprite[] sprites = new Sprite[4];

    bool isLanding = false;

    private void Start()
    {
        runway = GameObject.Find("Runway");  
        spriteRenderer = GetComponent<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
        rigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.Rotate(0, 0, Random.Range(0, 360));
        speed = Random.Range(1, 3);
        int spriteRandSelect = Random.Range(0, 3);
        spriteRenderer.sprite = sprites[spriteRandSelect];

        RWboxcollider = runway.GetComponent<BoxCollider2D>();
        RWScript = runway.GetComponent<Runway>();
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0)
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;
        }

        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
        isLanding = RWboxcollider.OverlapPoint(transform.position);
        if (isLanding)
        {
            timerValue += 0.5f * Time.deltaTime;
            float interpolation = landing.Evaluate(timerValue);

            if(transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
                RWScript.addScore();
            }

            transform.localScale = Vector3.Lerp(Vector3.one*3, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0)
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i+1));
                }
                lineRenderer.positionCount--;
            }
        }

        if(Camera.main.WorldToScreenPoint(transform.position).x < 0 || Camera.main.WorldToScreenPoint(transform.position).x > Screen.width || Camera.main.WorldToScreenPoint(transform.position).y < 0 || Camera.main.WorldToScreenPoint(transform.position).y > Screen.height)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Vector2.Distance(newPosition, lastPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Vector3.Distance(transform.position, collision.transform.position) < 1 && collision.name.Contains("Plane"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = Color.red;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        spriteRenderer.color = Color.white;
    }

}
