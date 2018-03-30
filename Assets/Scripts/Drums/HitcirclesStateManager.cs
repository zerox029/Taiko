using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitcirclesStateManager : MonoBehaviour {

    public GameObject dynamic;
    public GameObject missGlow;
    public GameObject okGlow;
    public GameObject perfectGlow;

    public Vector3 glowPosition;

    SpriteRenderer rend;

    Chart chart;

    private void Start()
    {
        glowPosition.x = -4.5f;
        glowPosition.y = GameObject.FindGameObjectWithTag("ScrollBar").transform.position.y;
        chart = FindObjectOfType<Chart>();
    }

    public void Hit(float hitTiming)
    {
        float minTiming = chart.timings[0] - chart.hitTimingWindow;
        float maxTiming = chart.timings[0] + chart.hitTimingWindow;

        //Checking if player has hit the right key
        

        if (hitTiming >= minTiming && hitTiming <= maxTiming)
        {
            float offset = hitTiming - chart.timings[0];
            Debug.Log("hit with " + offset + "ms offset");

            Perfect();

            chart.RemoveFirstHitcirle();
        }
    }

    public void Miss()
    {
        GameObject glowInstance = Instantiate(missGlow,glowPosition, Quaternion.identity, dynamic.transform);
        rend = glowInstance.GetComponent<SpriteRenderer>();
        StartCoroutine(FadeGlow(0.4f, rend, glowInstance));
    }

    public void Okay()
    {
        GameObject glowInstance = Instantiate(okGlow, glowPosition, Quaternion.identity, dynamic.transform);
        rend = glowInstance.GetComponent<SpriteRenderer>();
        StartCoroutine(FadeGlow(0.4f, rend, glowInstance));
    }

    public void Perfect()
    {
        GameObject glowInstance = Instantiate(perfectGlow, glowPosition, Quaternion.identity, dynamic.transform);
        rend = glowInstance.GetComponent<SpriteRenderer>();
        StartCoroutine(FadeGlow(0.4f, rend, glowInstance));
    }

    IEnumerator FadeGlow(float aTime, SpriteRenderer rend, GameObject glowInstance)
    {
        float alpha = rend.color.a;
        for(float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            if(rend)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, 0, t));
                rend.color = newColor;
                yield return null;
            }
            else
            {
                yield return null;
            }
        }

        if(glowInstance) Destroy(glowInstance);
    }
}
