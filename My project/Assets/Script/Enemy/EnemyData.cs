using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName ="ScriptableObject/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public float damage;
}
