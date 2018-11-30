using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    private float damage;
    private ModEffect effect;
    private Collider2D enemy;
    internal void Fire(ModEffect effect, float damage, Gradient flameColor, Collider2D enemy)
    {
        this.effect = effect;
        this.damage = damage;
        var module = GetComponent<ParticleSystem>().colorOverLifetime;
        module.color = flameColor;
        this.enemy = enemy;
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Paricle collided");
        if (other.tag == "Player" || enemy == other.GetComponent<Collider2D>())
            return;
        if (other.tag == "Enemy")
        {
            if (effect == ModEffect.Fire)
                StartCoroutine(DamageEffects.FireDamage(this, damage / 2, 3, 0.5f,
                    other.GetComponent<HealthController>()));
            if (effect == ModEffect.Toxic)
                StartCoroutine(DamageEffects.ToxicDamage(this, damage / 3, 5, 0.5f,
                    other.GetComponent<HealthController>()));
            if (effect == ModEffect.Ice)
                StartCoroutine(DamageEffects.IceDamage(this, damage, 2,
                    other.GetComponent<HealthController>(), other.GetComponent<EnemyController>()));
        }

    }
}