using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlip : MonoBehaviour
{

    private Vector3 startScale;

    public SpriteRenderer PlayerSpriteRenderer;
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

	    if (transform.rotation.eulerAngles.z < 45 && transform.rotation.eulerAngles.z > 0 ||
	        transform.rotation.eulerAngles.z < 360 && transform.rotation.eulerAngles.z > 315)
	    {
	        PlayerSpriteRenderer.sortingOrder = 100;
        }
	    else
	    {
	        PlayerSpriteRenderer.sortingOrder = 90;
	    }

    }
}
