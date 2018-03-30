using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClock : MonoBehaviour {

    float startTime;

	void Awake ()
    {
        restartClock();
	}

	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            restartClock();
        }
	}

    void restartClock()
    {
        startTime = Time.time;
    }

    public float getTime()
    {
        return Time.time - startTime;
    }
}
