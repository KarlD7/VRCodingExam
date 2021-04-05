using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
    }

    void OnGui()
    {
        GUI.Box(new Rect(20, 20, 170, 25), "Time Played: " + time);
        if (time >= 60)
        {
            GUI.Box(new Rect(Screen.width / 2 - 120, Screen.height / 2, 300, 50), "You have completed the simulation");
            Time.timeScale = 0.0f;
        }
    }
}
