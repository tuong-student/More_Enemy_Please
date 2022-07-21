using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyScript : MonoBehaviour, IDamageable
{
    #region Component
    [SerializeField] EnemyData enemyData;
    [SerializeField] SpriteRenderer sr;
    ParticleSystem enemyDeadEffect;
    Rigidbody2D rb;
    AIPath enemyAIPath;
    AIDestinationSetter destinationSetter;
    Transform targetTransform;
    #endregion

    #region Stats
    float currentHealth;
    float maxHealth;
    float damage;
    Queue<Action> actions = new Queue<Action>();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAIPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyDeadEffect = Resources.Load<ParticleSystem>("Prefabs/ParticleSystem/EnemyDeadEffect");

        this.maxHealth = enemyData.maxHealth;
        this.damage = enemyData.damage;

        this.currentHealth = maxHealth;
    }

    void Update()
    {
        if(enemyData != null){
            this.destinationSetter.target = targetTransform;
            this.enemyAIPath.maxSpeed = enemyData.moveSpeed;
        }
        if(currentHealth <= 0)
        {
            Dead();
        }

        if(actions.Count > 0){
            Action action = actions.Dequeue();
            action();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
            damageableObject.Damage(damage);
    }
    
    public void SetData(EnemyData enemyData){
        this.maxHealth = enemyData.maxHealth;
        this.damage = enemyData.damage;
        this.enemyData = enemyData;
    }

    public void Damage(float damage)
    {
        this.currentHealth -= damage;
    }

    public void Dead(){
        rb.velocity = Vector3.zero;
        ParticleSystem enemyDeadE = Instantiate(enemyDeadEffect, this.transform.position, Quaternion.identity);
        Destroy(enemyDeadE.gameObject, 4f);
        Destroy(this.gameObject);
    }

    public void PushBack(Vector3 direction)
    {
        enemyAIPath.enabled = false;
        rb.velocity = Vector3.zero;
        GetComponent<Rigidbody2D>().AddForce(direction * 10f);
        NOOD.FunctionDelay.StartThreadDelayFunction(Recover, 0.3f,actions);
    }

    void Recover(){
        enemyAIPath.enabled = true;
    }
}
