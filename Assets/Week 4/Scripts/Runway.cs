using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runway : MonoBehaviour
{
    public int score = 0;
    public void addScore()
    {
        score++;
        Debug.Log(score);
    }
}
