using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerStatusScript : MonoBehaviour
{


    private TMP_Text textComponent;
    void Start()
    {
        textComponent = GetComponent<TMP_Text>();
        getTimer();
    }
    
    public void getTimer()
    {
        textComponent.text = Timer.instance.textComponent.text;
    }
}
