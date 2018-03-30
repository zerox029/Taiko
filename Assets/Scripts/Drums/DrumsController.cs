using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumsController : MonoBehaviour {

    GameClock clock;
    AudioManager audioManager;
    Chart chart;

    float hitTiming;

    GameObject leftOuterDrum;
    GameObject rightOuterDrum;
    GameObject leftInnerDrum;
    GameObject rightInnerDrum;

    void Start()
    {
        clock = FindObjectOfType<GameClock>();
        chart = FindObjectOfType<Chart>();

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

    private void checkIfHitcircle(int drumType)
    {
        FindObjectOfType<HitcirclesStateManager>().Hit(hitTiming, drumType);
    }

    void hitDrumsVisuals()
    {
        //Left outer drum
        if(Input.GetButtonDown("LeftOuterDrum"))
        {
            leftOuterDrum.SetActive(true);

            audioManager.Play("normalHitclap");
        }
        if (!Input.GetButton("LeftOuterDrum"))
        {
            leftOuterDrum.SetActive(false);
        }

        //Right outer drum
        if (Input.GetButtonDown("RightOuterDrum"))
        {
            rightOuterDrum.SetActive(true);

            audioManager.Play("normalHitclap");
        }
        if (!Input.GetButton("RightOuterDrum"))
        {
            rightOuterDrum.SetActive(false);
        }

        //Left inner drum
        if (Input.GetButtonDown("LeftInnerDrum"))
        {
            leftInnerDrum.SetActive(true);

            audioManager.Play("normalHitnormal");
        }
        if (!Input.GetButton("LeftInnerDrum"))
        {
            leftInnerDrum.SetActive(false);
        }

        //Right inner drum
        if (Input.GetButtonDown("RightInnerDrum"))
        {
            rightInnerDrum.SetActive(true);

            audioManager.Play("normalHitnormal");
        }
        if (!Input.GetButton("RightInnerDrum"))
        {
            rightInnerDrum.SetActive(false);
        }
    }

    void hitDrumsTiming()
    {
        //Left outer drum
        if (Input.GetButtonDown("LeftOuterDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle(2);
        }

        //Right outer drum
        if (Input.GetButtonDown("RightOuterDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle(2);
        }

        //Left inner drum
        if (Input.GetButtonDown("LeftInnerDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle(1);
        }

        //Right inner drum
        if (Input.GetButtonDown("RightInnerDrum"))
        {
            hitTiming = clock.getTime();

            if (chart.timings.Count > 0) checkIfHitcircle(1);
        }
    }
}
