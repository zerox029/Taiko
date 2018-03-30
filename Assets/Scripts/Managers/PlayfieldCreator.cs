using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayfieldCreator : MonoBehaviour {

    //The gameobject in which all elements must be instantiated
    public GameObject playArea;

    public GameObject barRight; //Scrolling bar
    public GameObject barLeft;
    public GameObject hitArea;

	void Start ()
    {
        InstantiateAll();
	}

	void InstantiateAll()
    {
        barRight = Instantiate(barRight, playArea.transform);

        Vector3 drumLocation = new Vector3(-7.5f, barRight.transform.position.y);
        barLeft = Instantiate(barLeft, drumLocation, Quaternion.identity, playArea.transform);

        Vector3 hitAreaLocation = new Vector3(-4.5f, barRight.transform.position.y);
        hitArea = Instantiate(hitArea, hitAreaLocation, Quaternion.identity, playArea.transform);
    }
}
