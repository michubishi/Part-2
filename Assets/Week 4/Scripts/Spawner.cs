
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer = 0;
    public GameObject plane;
    float spawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnTime)
        {
            Instantiate(plane);
            spawnTime = Random.Range(1, 5);
            timer = 0;
        }
    }
}
