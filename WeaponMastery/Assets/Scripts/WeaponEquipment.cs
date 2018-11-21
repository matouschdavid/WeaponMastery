using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipment : MonoBehaviour
{
    public GameObject EquipmentUI;

    public Weapon Weapon;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void ChangeEquipment()
    {
        EquipmentUI.SetActive(true);

    }
}
