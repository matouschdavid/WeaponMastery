using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipmentUI : MonoBehaviour
{
    public GameObject EquipmentPartTemplate;

    public Weapon Weapon;

    public GameObject StatSlot;

    public GameObject BulletSlot;

    public GameObject ImpactSlot;

    public Transform OptionsGrid;

    public WeaponEquipmentPart[] EquipmentParts;

    private WeaponPartType CurrentWeaponPartType = WeaponPartType.Impact;

    public float DragThreshHold;

    void OnEnable()
    {
        ShowAvailableParts();
    }

    void ShowAvailableParts()
    {
        foreach (var wep in GameObject.FindGameObjectsWithTag("WeaponEquipmentPartUI"))
        {
            if (wep.transform.parent.gameObject == OptionsGrid.gameObject)
                Destroy(wep);
        }
        int i = 0;
        foreach (var weaponEquipmentPart in EquipmentParts)
        {
            if (weaponEquipmentPart.WeaponPartType == CurrentWeaponPartType)
            {
                GameObject g = Instantiate(EquipmentPartTemplate);
                g.transform.SetParent(OptionsGrid);
                g.transform.localPosition = Vector3.zero;
                g.transform.localScale = Vector3.one;
                g.GetComponent<WeaponEquipmentPart>().Id = i;
                g.GetComponent<WeaponEquipmentPart>().EquipmentUi = this;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = weaponEquipmentPart.WeaponPartSprite;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartType = weaponEquipmentPart.WeaponPartType;
            }

            i++;
        }
    }

    internal void ReleasedEquipmentPart(WeaponEquipmentPart weaponEquipmentPart)
    {
        if (Vector2.Distance(weaponEquipmentPart.transform.position, StatSlot.transform.position) <= DragThreshHold && weaponEquipmentPart.WeaponPartType == WeaponPartType.Stat)
        {
            weaponEquipmentPart.gameObject.transform.SetParent(StatSlot.transform);
            weaponEquipmentPart.transform.localPosition = Vector3.zero;
            weaponEquipmentPart.transform.localScale = Vector3.one * 1.3f;
            Weapon.StatEquipmentPart = weaponEquipmentPart;
            weaponEquipmentPart.WeaponPartImage.raycastTarget = false;

        }
        else if (Vector2.Distance(weaponEquipmentPart.transform.position, BulletSlot.transform.position) <= DragThreshHold && weaponEquipmentPart.WeaponPartType == WeaponPartType.Bullet)
        {
            weaponEquipmentPart.gameObject.transform.SetParent(BulletSlot.transform);
            weaponEquipmentPart.transform.localPosition = Vector3.zero;
            weaponEquipmentPart.transform.localScale = Vector3.one * 1.3f;
            Weapon.BulletEquipmentPart = weaponEquipmentPart;
            weaponEquipmentPart.WeaponPartImage.raycastTarget = false;

        }
        else if (Vector2.Distance(weaponEquipmentPart.transform.position, ImpactSlot.transform.position) <= DragThreshHold && weaponEquipmentPart.WeaponPartType == WeaponPartType.Impact)
        {
            weaponEquipmentPart.gameObject.transform.SetParent(ImpactSlot.transform);
            weaponEquipmentPart.transform.localPosition = Vector3.zero;
            weaponEquipmentPart.transform.localScale = Vector3.one * 1.3f;
            Weapon.ImpactEquipmentPart = weaponEquipmentPart;
            weaponEquipmentPart.WeaponPartImage.raycastTarget = false;

        }
        else
        {
            weaponEquipmentPart.transform.SetParent(OptionsGrid);
        }
        ShowAvailableParts();

    }

    public void ChangeSelection(string newType)
    {
        CurrentWeaponPartType = newType == "Bullet" ? WeaponPartType.Bullet : newType == "Impact" ? WeaponPartType.Impact : WeaponPartType.Stat;
        ShowAvailableParts();
    }
}
