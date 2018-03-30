using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsController : MonoBehaviour {

    GameClock clock;
    AudioManager audioManager;
    Chart chart;

    float hitTiming;
    List<KeyCode> heldKeys;

    KeyCode leftOuterKey;
    KeyCode rightOuterKey;
    KeyCode leftInnerKey;
    KeyCode rightInnerKey;

    GameObject leftOuterDrum;
    GameObject rightOuterDrum;
    GameObject leftInnerDrum;
    GameObject rightInnerDrum;

    void Start()
    {
        clock = FindObjectOfType<GameClock>();
        chart = FindObjectOfType<Chart>();

        leftOuterKey = KeyCode.A;
        rightOuterKey = KeyCode.Quote;
        leftInnerKey = KeyCode.S;
        rightInnerKey = KeyCode.Semicolon;

        heldKeys = new List<KeyCode>();

        leftOuterDrum = gameObject.transform.Find("drum-outer-left").gameObject;
        rightOuterDrum = gameObject.transform.Find("drum-outer-right").gameObject;
        leftInnerDrum = gameObject.transform.Find("drum-inner-left").gameObject;
        rightInnerDrum = gameObject.transform.Find("drum-inner-right").gameObject;

        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update ()
    {
        hitDrumsVisuals();
        hitDrumsTiming();
	}

    private void checkIfHitcircle()
    {
        FindObjectOfType<HitcirclesStateManager>().Hit(hitTiming);
    }

    void hitDrumsVisuals()
    {
        //Left outer drum
        if(Input.GetKeyDown(leftOuterKey))
        {
            leftOuterDrum.SetActive(true);
            heldKeys.Add(leftOuterKey);

            audioManager.Play("normalHitclap");
        }
        if (!Input.GetKey(leftOuterKey))
        {
            if (heldKeys.Contains(leftOuterKey)) heldKeys.Remove(leftOuterKey);
            leftOuterDrum.SetActive(false);
        }

        //Right outer drum
        if (Input.GetKeyDown(rightOuterKey))
        {
            rightOuterDrum.SetActive(true);
            heldKeys.Add(rightOuterKey);

            audioManager.Play("normalHitclap");
        }
        if (!Input.GetKey(rightOuterKey))
        {
            if (heldKeys.Contains(rightOuterKey)) heldKeys.Remove(rightOuterKey);
            rightOuterDrum.SetActive(false);
        }

        //Left inner drum
        if (Input.GetKeyDown(leftInnerKey))
        {
            leftInnerDrum.SetActive(true);
            heldKeys.Add(leftInnerKey);

            audioManager.Play("normalHitnormal");
        }
        if (!Input.GetKey(leftInnerKey))
        {
            if (heldKeys.Contains(leftInnerKey)) heldKeys.Remove(leftInnerKey);
            leftInnerDrum.SetActive(false);
        }

        //Right inner drum
        if (Input.GetKeyDown(rightInnerKey))
        {
            rightInnerDrum.SetActive(true);
            heldKeys.Add(rightInnerKey);

            audioManager.Play("normalHitnormal");
        }
        if (!Input.GetKey(rightInnerKey))
        {
            if (heldKeys.Contains(rightInnerKey)) heldKeys.Remove(rightInnerKey);
            rightInnerDrum.SetActive(false);
        }
    }

    void hitDrumsTiming()
    {
        //Left outer drum
        if (Input.GetButtonDown("LeftOuterDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle();
        }

        //Right outer drum
        if (Input.GetButtonDown("RightOuterDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle();
        }

        //Left inner drum
        if (Input.GetButtonDown("LeftInnerDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle();
        }

        //Right inner drum
        if (Input.GetButtonDown("RightInnerDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle();
        }
    }
}
