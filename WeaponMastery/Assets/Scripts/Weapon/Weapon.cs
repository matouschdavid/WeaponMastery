using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public ParticleSystem Flame;

    public Gradient BasicGradient;

    public StatWeaponPart StatEquipmentPart;

    public BulletWeaponPart BulletEquipmentPart;

    public ImpactWeaponPart ImpactEquipmentPart;

    public Transform FirePosition;

    private float lastFire = 0;

    public bool CanShoot = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    lastFire += Time.deltaTime;
	    if (Input.GetMouseButton(0) && lastFire >= StatEquipmentPart.AttackSpeed && CanShoot)
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

    public void UpdateWeapon()
    {
        Gradient gradient = BasicGradient;
        //Debug.Log(BulletEquipmentPart.FlameColor);
        gradient.colorKeys[0] = new GradientColorKey(BulletEquipmentPart.FlameColor, gradient.colorKeys[0].time);
        gradient.colorKeys[1] = new GradientColorKey(ImpactEquipmentPart.FlameColor, gradient.colorKeys[1].time);
        gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(BulletEquipmentPart.FlameColor, gradient.colorKeys[0].time), new GradientColorKey(ImpactEquipmentPart.FlameColor, gradient.colorKeys[1].time)}, gradient.alphaKeys);
        var colorModule = Flame.colorOverLifetime;
        colorModule.color = gradient;
        //BasicGradient = gradient;
    }
}
