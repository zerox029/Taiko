using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitcircleInstantiator : MonoBehaviour {

    public GameObject dynamic;

    public GameObject hitcircleInner;
    public GameObject hitcircleOuter;

    Vector3 startingPosition;

    int hitobjectsCount = 0;

    void Start()
    {
        startingPosition.x = 9.6f;
        startingPosition.y = GameObject.FindGameObjectWithTag("ScrollBar").transform.position.y;
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject hitCircle = Instantiate(hitcircleInner, startingPosition, Quaternion.identity, dynamic.transform);
            hitCircle.GetComponent<Hitcircle>().objectId = hitobjectsCount;

            hitobjectsCount++;
        }
        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
            GameObject hitCircle = Instantiate(hitcircleOuter, startingPosition, Quaternion.identity, dynamic.transform);
            hitCircle.GetComponent<Hitcircle>().objectId = hitobjectsCount;

            hitobjectsCount++;
        }
	}
}
