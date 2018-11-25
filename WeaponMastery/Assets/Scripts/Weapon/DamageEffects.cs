using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEffects : MonoBehaviour
{
    private static float damagettl = 0.3f;
    public static IEnumerator FireDamage(Bullet bullet, float damage, int ticks, float ticksInterval, HealthController target)
    {
        for (int i = 0; i < ticks; i++)
        {
            target.Health -= damage;
            GameObject t = Instantiate<GameObject>(Resources.Load<GameObject>("DamageText"), target.transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0), Quaternion.identity);
            t.transform.SetParent(target.transform);
            t.GetComponent<TextMesh>().text = damage.ToString("###");
            Destroy(t, damagettl);
            yield return new WaitForSeconds(ticksInterval);
        }
        Destroy(bullet.gameObject);
    }

    public static IEnumerator IceDamage(Bullet bullet, float damage, float stunDuration, HealthController targetHealth, EnemyController targetController)
    {
        targetHealth.Health -= damage;
        GameObject t = Instantiate<GameObject>(Resources.Load<GameObject>("DamageText"), targetHealth.transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0), Quaternion.identity);
        t.transform.SetParent(targetHealth.transform);
        t.GetComponent<TextMesh>().text = damage.ToString("###");
        Destroy(t, damagettl);
        targetController.enabled = false;
        yield return new WaitForSeconds(stunDuration);
        targetController.enabled = true;
        Destroy(bullet.gameObject);
    }

    public static IEnumerator ToxicDamage(Bullet bullet, float damage, int ticks, float ticksInterval, HealthController target)
    {
        for (int i = 0; i < ticks; i++)
        {
            Debug.Log("Ticks: " + ticks);
            target.Health = 100;
            target.Health -= damage;
            GameObject t = Instantiate<GameObject>(Resources.Load<GameObject>("DamageText"), target.transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0), Quaternion.identity);
            t.transform.SetParent(target.transform);
            t.GetComponent<TextMesh>().text = damage.ToString("###");
            Destroy(t, damagettl); yield return new WaitForSeconds(ticksInterval);
        }
        Destroy(bullet.gameObject);
    }
}
