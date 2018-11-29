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

    public void OnFire(Transform firePosition, float damage, ImpactWeaponPart impact)
    {
        GameObject bullet = Instantiate(Bullet, firePosition.position, firePosition.rotation);
        bullet.GetComponent<Bullet>().Fire(Effect, BulletSpeed, damage, impact);
    }
}

public enum ModEffect
{
    Fire,
    Toxic,
    Ice,
    Lightning
}
