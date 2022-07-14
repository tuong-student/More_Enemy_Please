using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript: MonoBehaviour
{
    #region Component
    [SerializeField] Transform shootingPoint;
    GameObject bullet;
    GunData gunData;
    #endregion

    #region Stats
    [SerializeField] float bulletForce;
    #endregion

    private void Awake()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    public void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shootingPoint.position, shootingPoint.transform.rotation);
        Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(shootingPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
