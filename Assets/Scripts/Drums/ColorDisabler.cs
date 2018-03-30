using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDisabler : MonoBehaviour {

	void Update ()
    {
        if(this.enabled)
        {
            StartCoroutine(disableColor());
        }
	}

    IEnumerator disableColor()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
