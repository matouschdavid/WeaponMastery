using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatWeaponPart : WeaponEquipmentPart
{
    public float AttackSpeed;
    public float AttackDamage;
    public override void OnRelease()
    {
        Debug.Log("Is releasing");
        EquipmentUi.ReleasedEquipmentPart(Id, WeaponPartType.Stat, this);

    }
}
