using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GunScript: MonoBehaviour
{
    #region Component
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Transform shootingPoint;
    [SerializeField] GunData gunData;
    [SerializeField] ParticleSystem shootingEffect;
    GameObject bullet;
    #endregion

    #region Stats
    [SerializeField] float bulletForce;
    #endregion

    private void Awake()
    {
        bullet = gunData.bullet;
        sr.sprite = gunData.sprite;
    }

    public void Shoot()
    {
        ParticleSystem ShootE = Instantiate(shootingEffect, shootingPoint.transform.position, shootingEffect.transform.rotation);
        Destroy(ShootE.gameObject, 1f);

        GameObject newBullet = Instantiate(bullet, shootingPoint.position, shootingPoint.transform.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingPoint.up * bulletForce, ForceMode2D.Impulse);

        CustomCamera.InsCustomCamera.Shake();
    }

    public void ReCoil()
    {
        this.transform.localPosition = this.transform.right * -0.2f;
        Invoke("DownCoil", 0.2f);
    }

    void DownCoil()
    {
        this.transform.localPosition = Vector3.zero;
    }
}
