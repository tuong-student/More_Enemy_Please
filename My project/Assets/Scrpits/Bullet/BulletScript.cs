using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletScript : MonoBehaviour
{
    #region Components
    ParticleSystem bulletEffect;
    #endregion

    #region Stats
    float damage;
    public BulletData data;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        this.damage = data.damage;
        bulletEffect = Resources.Load<ParticleSystem>("Prefabs/ParticleSystem/BulletEffect");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if(damageableObject != null){
            damageableObject.Damage(damage);
            damageableObject.PushBack(transform.up);
        }

        if(collision.gameObject.CompareTag("Obstacles")){
            ParticleSystem bulletE = Instantiate(bulletEffect, this.transform.position, this.transform.rotation);
            Destroy(bulletE.gameObject, 1f);
            Destroy(this.gameObject);
        }
    }
}
