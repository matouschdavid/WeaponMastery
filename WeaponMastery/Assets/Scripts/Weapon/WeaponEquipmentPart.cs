using UnityEngine;
using UnityEngine.UI;

public class WeaponEquipmentPart : MonoBehaviour
{
    public Sprite WeaponPartSprite;
    public WeaponPartType WeaponPartType;
    public WeaponEquipmentUI EquipmentUi;
    public int Id;
    public string Name;

    public Image WeaponPartImage;

    public virtual void OnImpact()
    {

    }

    public virtual void OnFire()
    {

    }

    public void OnDrag()
    {
        Debug.Log("Is dragging");
        transform.position = Input.mousePosition;
    }

    public virtual void OnRelease()
    {

        

    }

    public void OnGrab()
    {

        Debug.Log("Is grabbing");

    }
}

public enum WeaponPartType
{
    Stat,
    Bullet,
    Impact
}