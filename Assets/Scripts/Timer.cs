using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private float startTime;
    public static string outputTime;
    public TMP_Text textComponent;
    public static Timer instance;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        startTime = Time.time;
        textComponent = GetComponent<TMP_Text>();
    }
    
    void Update()
    {
        outputTime = $"Time alive: {Time.time - startTime}";
    
        textComponent.text = outputTime;
    }
}
