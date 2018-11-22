using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEquipmentUI : MonoBehaviour
{
    public GameObject BulletPartTemplate;
    public GameObject StatPartTemplate;
    public GameObject ImpactPartTemplate;

    public Weapon Weapon;

    public GameObject StatSlot;

    public GameObject BulletSlot;

    public GameObject ImpactSlot;

    public Transform OptionsGrid;

    public StatWeaponPart[] StatEquipmentParts;
    public BulletWeaponPart[] BulletEquipmentParts;
    public ImpactWeaponPart[] ImpactEquipmentParts;


    private WeaponPartType CurrentWeaponPartType = WeaponPartType.Impact;

    public float DragThreshHold;

    void Start()
    {
        //gameObject.SetActive(false);
    }

    void OnEnable()
    {
        Time.timeScale = 0.05f;
        string weapon = PlayerPrefs.GetString("Weapon");
        string[] partNames = weapon.Split('|');
        Debug.Log(weapon);
        Weapon.StatEquipmentPart = StatEquipmentParts[0];
        Weapon.BulletEquipmentPart = BulletEquipmentParts[0];
        Weapon.ImpactEquipmentPart = ImpactEquipmentParts[0];
        int sC = 0;
        int bC = 0;
        int iC = 0;
        if (partNames.Length == 3)
        {
            string statMod = partNames[0];
            string bulletMod = partNames[1];
            string impactMod = partNames[2];
            
            foreach (var statEquipmentPart in StatEquipmentParts)
            {
                if (statEquipmentPart.Name == statMod)
                {
                    Weapon.StatEquipmentPart = statEquipmentPart;
                    break;
                }

                sC++;
            }
            foreach (var bulletEquipmentPart in BulletEquipmentParts)
            {
                if (bulletEquipmentPart.Name == bulletMod)
                {
                    Weapon.BulletEquipmentPart = bulletEquipmentPart;
                    break;
                }

                bC++;
            }
            foreach (var impactEquipmentPart in ImpactEquipmentParts)
            {
                if (impactEquipmentPart.Name == impactMod)
                {
                    Weapon.ImpactEquipmentPart = impactEquipmentPart;
                    break;
                }

                iC++;
            }
        }

        Weapon.StatEquipmentPart.Id = sC;
        Weapon.BulletEquipmentPart.Id = bC;
        Weapon.ImpactEquipmentPart.Id = iC;
        GameObject g = Instantiate(StatPartTemplate, StatSlot.transform);
        g.transform.localPosition = Vector3.zero;
        g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = StatEquipmentParts[Weapon.StatEquipmentPart.Id].WeaponPartSprite;
        ReleasedEquipmentPart(Weapon.StatEquipmentPart.Id, WeaponPartType.Stat, g.GetComponent<WeaponEquipmentPart>());

        g = Instantiate(BulletPartTemplate, BulletSlot.transform);
        g.transform.localPosition = Vector3.zero;
        g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = BulletEquipmentParts[Weapon.BulletEquipmentPart.Id].WeaponPartSprite;
        ReleasedEquipmentPart(Weapon.BulletEquipmentPart.Id, WeaponPartType.Bullet, g.GetComponent<WeaponEquipmentPart>());

        g = Instantiate(ImpactPartTemplate, ImpactSlot.transform);
        g.transform.localPosition = Vector3.zero;
        g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = ImpactEquipmentParts[Weapon.ImpactEquipmentPart.Id].WeaponPartSprite;
        ReleasedEquipmentPart(Weapon.ImpactEquipmentPart.Id, WeaponPartType.Impact, g.GetComponent<WeaponEquipmentPart>());
        ShowAvailableParts();
    }

    void OnDisable()
    {
        Time.timeScale = 1;
    }

    void ShowAvailableParts()
    {
        foreach (var wep in GameObject.FindGameObjectsWithTag("WeaponEquipmentPartUI"))
        {
            if (wep.transform.parent.gameObject == OptionsGrid.gameObject)
                Destroy(wep);
        }
        int i = 0;
        if (CurrentWeaponPartType == WeaponPartType.Stat)
        {
            foreach (var weaponEquipmentPart in StatEquipmentParts)
            {
                GameObject g = Instantiate(StatPartTemplate);
                g.transform.SetParent(OptionsGrid);
                g.transform.localPosition = Vector3.zero;
                g.transform.localScale = Vector3.one;
                g.GetComponent<WeaponEquipmentPart>().Id = i;
                g.GetComponent<WeaponEquipmentPart>().EquipmentUi = this;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = weaponEquipmentPart.WeaponPartSprite;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartType = weaponEquipmentPart.WeaponPartType;
                i++;
            }

            
        }
        else if (CurrentWeaponPartType == WeaponPartType.Bullet)
        {
            i = 0;
            foreach (var weaponEquipmentPart in BulletEquipmentParts)
            {
                GameObject g = Instantiate(BulletPartTemplate);
                g.transform.SetParent(OptionsGrid);
                g.transform.localPosition = Vector3.zero;
                g.transform.localScale = Vector3.one;
                g.GetComponent<WeaponEquipmentPart>().Id = i;
                g.GetComponent<WeaponEquipmentPart>().EquipmentUi = this;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = weaponEquipmentPart.WeaponPartSprite;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartType = weaponEquipmentPart.WeaponPartType;
                i++;
            }

           
        }
        else if (CurrentWeaponPartType == WeaponPartType.Impact)
        {
            i = 0;
            foreach (var weaponEquipmentPart in ImpactEquipmentParts)
            {
                GameObject g = Instantiate(ImpactPartTemplate);
                g.transform.SetParent(OptionsGrid);
                g.transform.localPosition = Vector3.zero;
                g.transform.localScale = Vector3.one;
                g.GetComponent<WeaponEquipmentPart>().Id = i;
                g.GetComponent<WeaponEquipmentPart>().EquipmentUi = this;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartImage.sprite = weaponEquipmentPart.WeaponPartSprite;
                g.GetComponent<WeaponEquipmentPart>().WeaponPartType = weaponEquipmentPart.WeaponPartType;
                i++;
            }

           
        }


    }

    internal void ReleasedEquipmentPart(int id, WeaponPartType type, WeaponEquipmentPart weaponEquipmentPart)
    {
        Debug.Log(id + "  " + type);
        if (Vector2.Distance(weaponEquipmentPart.transform.position, StatSlot.transform.position) <= DragThreshHold && type == WeaponPartType.Stat)
        {
            weaponEquipmentPart.gameObject.transform.SetParent(StatSlot.transform);
            weaponEquipmentPart.transform.localPosition = Vector3.zero;
            weaponEquipmentPart.transform.localScale = Vector3.one * 1.3f;
            Weapon.StatEquipmentPart = StatEquipmentParts[id];
            weaponEquipmentPart.WeaponPartImage.raycastTarget = false;

        }
        else if (Vector2.Distance(weaponEquipmentPart.transform.position, BulletSlot.transform.position) <= DragThreshHold && type == WeaponPartType.Bullet)
        {
            weaponEquipmentPart.gameObject.transform.SetParent(BulletSlot.transform);
            weaponEquipmentPart.transform.localPosition = Vector3.zero;
            weaponEquipmentPart.transform.localScale = Vector3.one * 1.3f;
            Weapon.BulletEquipmentPart = BulletEquipmentParts[id];
            weaponEquipmentPart.WeaponPartImage.raycastTarget = false;

        }
        else if (Vector2.Distance(weaponEquipmentPart.transform.position, ImpactSlot.transform.position) <= DragThreshHold && type == WeaponPartType.Impact)
        {
            weaponEquipmentPart.gameObject.transform.SetParent(ImpactSlot.transform);
            weaponEquipmentPart.transform.localPosition = Vector3.zero;
            weaponEquipmentPart.transform.localScale = Vector3.one * 1.3f;
            Weapon.ImpactEquipmentPart = ImpactEquipmentParts[id];
            weaponEquipmentPart.WeaponPartImage.raycastTarget = false;

        }
        else
        {
            weaponEquipmentPart.transform.SetParent(OptionsGrid);
        }

        PlayerPrefs.SetString("Weapon", Weapon.StatEquipmentPart.Name + "|" + Weapon.BulletEquipmentPart.Name + "|" + Weapon.ImpactEquipmentPart.Name);
        ShowAvailableParts();

    }

    public void ChangeSelection(string newType)
    {
        CurrentWeaponPartType = newType == "Bullet" ? WeaponPartType.Bullet : newType == "Impact" ? WeaponPartType.Impact : WeaponPartType.Stat;
        ShowAvailableParts();
    }
}
