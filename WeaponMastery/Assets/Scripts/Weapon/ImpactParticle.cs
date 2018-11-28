using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    public Bullet[] bullets;

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    public void Fire(ModEffect effect, float speed, float damage, Collider2D enemy)
    {
        foreach (var bullet in bullets)
        {
            bullet.Fire(effect, speed, damage, enemy: enemy);
        }
    }
}
