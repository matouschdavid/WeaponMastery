using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WeaponEquipmentPart : MonoBehaviour
{
    public Sprite WeaponPartSprite;
    public WeaponPartType WeaponPartType;
    public WeaponEquipmentUI EquipmentUi;
    public Color FlameColor;
    public int Id;
    public string Name;

    public Image WeaponPartImage;

    public virtual void OnImpact()
    {

    }

    public void Disable()
    {
        WeaponPartImage.raycastTarget = false;
        GetComponent<EventTrigger>().enabled = false;
    }
    public void Enable()
    {
        WeaponPartImage.raycastTarget = true;
        GetComponent<EventTrigger>().enabled = true;
    }

    public virtual void OnFire()
    {

    }

    public void OnDrag()
    {
        var t = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(t.x, t.y, 0);
    }

    public virtual void OnRelease()
    {

        

    }

    public void OnGrab()
    {
        transform.parent = EquipmentUi.transform;
        Debug.Log("Is grabbing");

    }
}

public enum WeaponPartType
{
    Stat,
    Bullet,
    Impact
}