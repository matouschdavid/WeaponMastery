using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeaponPart : WeaponEquipmentPart
{

    public ModEffect Effect;
    public GameObject Bullet;
    public float BulletSpeed;

    public override void OnRelease()
    {
        Debug.Log("Is releasing");
        EquipmentUi.ReleasedEquipmentPart(Id, WeaponPartType.Bullet, this);

    }

    public void OnFire(Transform firePosition, float direction, float damage, ImpactWeaponPart impact, Gradient flameColor)
    {
        GameObject bullet = Instantiate(Bullet, firePosition.position, Quaternion.Euler(0,0,direction));
        bullet.GetComponent<Bullet>().Fire(Effect, BulletSpeed, damage, impact);
        var module = bullet.GetComponent<ParticleSystem>().colorOverLifetime;
        module.color = flameColor;
        
    }
}

public enum ModEffect
{
    Fire,
    Toxic,
    Ice,
    Lightning
}
