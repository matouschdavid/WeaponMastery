using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticle : MonoBehaviour
{
    public float damage;
    public ModEffect effect;

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Here");
        if (effect == ModEffect.Fire)
            StartCoroutine(DamageEffects.FireDamage(null, damage / 2, 3, 0.5f,
                other.GetComponent<HealthController>()));
        if (effect == ModEffect.Toxic)
            StartCoroutine(DamageEffects.ToxicDamage(null, damage / 3, 5, 0.5f,
                other.GetComponent<HealthController>()));
        if (effect == ModEffect.Ice)
            StartCoroutine(DamageEffects.IceDamage(null, damage, 2,
                other.GetComponent<HealthController>(), other.GetComponent<EnemyController>()));
    }
}
