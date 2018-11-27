using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlip : MonoBehaviour
{

    private Vector3 startScale;
	// Use this for initialization
	void Start ()
	{
	    startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.rotation.eulerAngles.z > 180)
	    {
	        transform.localScale = startScale;
	    }else if (transform.rotation.eulerAngles.z < 180)
	    {
	        transform.localScale = new Vector3(startScale.x * -1, startScale.y, startScale.z);
	    }
	}
}
