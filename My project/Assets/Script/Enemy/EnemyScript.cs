using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour, IDamageable
{
    #region Component
    [SerializeField]
    EnemyData enemyData;
    #endregion

    #region Stats
    float currentHealth;
    float maxHealth;
    float moveSpeed;
    float damage;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        this.maxHealth = enemyData.maxHealth;
        this.moveSpeed = enemyData.moveSpeed;
        this.damage = enemyData.damage;

        this.currentHealth = maxHealth;
    }

    void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Enemy Dead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
            damageableObject.Damage(damage);
    }

    public void Damage(float damage)
    {
        this.currentHealth -= damage;
    }
}
