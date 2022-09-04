using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGameScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void ExitGame()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }
}
