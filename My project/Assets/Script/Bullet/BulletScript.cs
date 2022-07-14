using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float damage;

    [SerializeField]
    BulletData data;

    // Start is called before the first frame update
    void Start()
    {
        this.damage = data.damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if(damageableObject != null)
            damageableObject.Damage(damage);
    }
}
