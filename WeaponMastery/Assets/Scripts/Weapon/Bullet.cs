using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private ModEffect effect;
    private float speed;
    private Rigidbody2D rb;
    private float damage;
    public ImpactWeaponPart impact;
    private Gradient flameColor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3);
    }

    public void Fire(ModEffect effect, float speed, float damage, ImpactWeaponPart impact, Gradient flameColor)
    {
        this.impact = impact;
        this.effect = effect;
        this.speed = speed;
        this.damage = damage;
        rb.velocity = transform.right * speed;
        this.flameColor = flameColor;
    }


    //void OnCollisionEnter2D(Collision2D collision2D)
    //{
    //    if (collision2D.gameObject.tag == "Player")
    //        return;
    //    if (collision2D.gameObject.tag == "Enemy")
    //    {
    //        GetComponent<Collider2D>().enabled = false;
    //        if (effect == ModEffect.Fire)
    //            StartCoroutine(DamageEffects.FireDamage(this, damage / 2, 3, 0.5f,
    //                collision2D.gameObject.GetComponent<HealthController>()));
    //        if (effect == ModEffect.Toxic)
    //            StartCoroutine(DamageEffects.ToxicDamage(this, damage / 3, 5, 0.5f,
    //                collision2D.gameObject.GetComponent<HealthController>()));
    //        if (effect == ModEffect.Ice)
    //            StartCoroutine(DamageEffects.IceDamage(this, damage, 2,
    //                collision2D.gameObject.GetComponent<HealthController>(), collision2D.gameObject.GetComponent<EnemyController>()));
    //        impact.OnFire(collision2D.transform, damage * 0.8f, speed * 0.2f, flameColor);
    //    }
    //    Destroy(gameObject);
    //}

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.gameObject.tag == "Player")
            return;
        if (collider2D.gameObject.tag == "Enemy")
        {
            GetComponent<Collider2D>().enabled = false;
            if (effect == ModEffect.Fire)
                StartCoroutine(DamageEffects.FireDamage(this, damage / 2, 3, 0.5f,
                    collider2D.gameObject.GetComponent<HealthController>()));
            if (effect == ModEffect.Toxic)
                StartCoroutine(DamageEffects.ToxicDamage(this, damage / 3, 5, 0.5f,
                    collider2D.gameObject.GetComponent<HealthController>()));
            if (effect == ModEffect.Ice)
                StartCoroutine(DamageEffects.IceDamage(this, damage, 2,
                    collider2D.gameObject.GetComponent<HealthController>(), collider2D.gameObject.GetComponent<EnemyController>()));
            impact.OnFire(transform, damage * 0.2f, speed * 0.2f, flameColor, collider2D);
        }
        else
        {
            impact.OnFire(transform, damage * 0.1f, speed * 0.2f, flameColor, collider2D, 0.3f);
        }
        Destroy(gameObject);
    }
}
