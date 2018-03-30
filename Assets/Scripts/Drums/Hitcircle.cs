using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitcircle : MonoBehaviour{

    GameClock gameClock;
    Chart chart;

    public int objectId;
    public int type;

    float speed;
    public float hitTiming;

    float travelTime = 2f;
    float travelDistance;

    void Update()
    {
        Approach();
        GetMiss();
    }

    void Start()
    {
        chart = FindObjectOfType<Chart>();

        gameClock = FindObjectOfType<GameClock>();
        hitTiming = gameClock.getTime() + travelTime;
        travelDistance = transform.position.x + 4.5f; //4.5 is the x position of the hit area
        speed = travelDistance / travelTime;

        gameObject.GetComponent<SpriteRenderer>().sortingOrder = objectId + 2;
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = objectId + 2;

        chart.hitObjects.Add(gameObject);
        chart.timings.Add(hitTiming);
    }

    void Approach()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    void GetMiss()
    {
        if(gameClock.getTime() - chart.hitTimingWindow > hitTiming)
        {
            FindObjectOfType<HitcirclesStateManager>().Miss();
        }
    }
}
