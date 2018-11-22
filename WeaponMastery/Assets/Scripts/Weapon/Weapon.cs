using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public StatWeaponPart StatEquipmentPart;

    public BulletWeaponPart BulletEquipmentPart;

    public ImpactWeaponPart ImpactEquipmentPart;

    public Transform FirePosition;

    private float lastFire = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    lastFire += Time.deltaTime;
	    if (Input.GetKeyDown(KeyCode.Space) && lastFire >= StatEquipmentPart.AttackSpeed)
	    {
	        lastFire = 0;
	        Shoot();
	    }
	}

    private void Shoot()
    {
        Debug.Log("Weapondamage: " + StatEquipmentPart.AttackDamage);
        BulletEquipmentPart.OnFire(FirePosition, StatEquipmentPart.AttackDamage, ImpactEquipmentPart);
    }
}
