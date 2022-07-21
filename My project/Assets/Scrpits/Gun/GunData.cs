using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GunData", menuName ="ScriptableObjects/GunData")]
public class GunData : ScriptableObject
{
    public GameObject bullet;
    public BulletData bulletData;
    public Sprite sprite;

    void OnEnable()
    {
        bullet.GetComponent<BulletScript>().data = bulletData;
    }
}
