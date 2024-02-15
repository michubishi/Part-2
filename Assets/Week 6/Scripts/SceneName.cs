using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{
    TextMeshProUGUI sceneNameLabel;
    void Start()
    {
        sceneNameLabel = GetComponent<TextMeshProUGUI>();
        sceneNameLabel.text = SceneManager.GetActiveScene().name;
    }


    void Update()
    {
        
    }
}
