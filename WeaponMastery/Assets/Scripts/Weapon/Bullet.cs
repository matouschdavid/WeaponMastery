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

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void Fire(ModEffect effect, float speed, float damage, ImpactWeaponPart impact)
    {
        this.impact = impact;
        this.effect = effect;
        this.speed = speed;
        this.damage = damage;
        Debug.Log(speed);
        rb.AddForce(transform.up * speed);
    }


    void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.tag == "Enemy")
        {
            GetComponent<Collider2D>().enabled = false;
            if (effect == ModEffect.Fire)
                StartCoroutine(DamageEffects.FireDamage(this, damage / 2, 3, 0.5f,
                    collision2D.gameObject.GetComponent<HealthController>()));
            if (effect == ModEffect.Toxic)
                StartCoroutine(DamageEffects.ToxicDamage(this, damage / 3, 5, 0.5f,
                    collision2D.gameObject.GetComponent<HealthController>()));
            if (effect == ModEffect.Ice)
                StartCoroutine(DamageEffects.IceDamage(this, damage, 2,
                    collision2D.gameObject.GetComponent<HealthController>(), collision2D.gameObject.GetComponent<EnemyController>()));
            impact.OnFire(collision2D.transform, damage * 0.8f);
        }
        Destroy(gameObject);
    }
}
