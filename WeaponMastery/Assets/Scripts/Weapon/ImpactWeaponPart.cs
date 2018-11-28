using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactWeaponPart : WeaponEquipmentPart
{
    public ModEffect Effect;
    public GameObject ParticleEffect;
    public Sprite EffectSprite;

    public override void OnRelease()
    {
        Debug.Log("Is releasing");
        EquipmentUi.ReleasedEquipmentPart(Id, WeaponPartType.Impact, this);

    }

    public void OnFire(Transform firePosition, float damage, float speed, Collider2D enemy)
    {
        Debug.Log(firePosition.position);
        GameObject g = Instantiate(ParticleEffect, firePosition);
        
        g.transform.localPosition = Vector3.zero;
        g.transform.parent = null;
        g.GetComponent<ImpactParticle>().Fire(Effect, speed, damage, enemy);
    }
}
