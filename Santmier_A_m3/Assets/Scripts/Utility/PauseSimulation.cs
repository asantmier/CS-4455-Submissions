using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSimulation : MonoBehaviour
{
    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        paused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (paused)
            {
                Time.timeScale = 1.0f;
                paused = false;
            } else
            {
                Time.timeScale = 0.0f;
                paused = true;
            }
        }
    }
}
