using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName ="ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float moveSpeed;
    public float damage;
}

public static class EnemyDataMaster{
    public static EnemyData[] GetDatas(){
        return Resources.LoadAll<EnemyData>("Prefabs/Data/Enemy");
    }

    public static EnemyData GetRandomData(){
        EnemyData[] enemyDatas = GetDatas();
        int r = Random.Range(0, enemyDatas.Length);
        return enemyDatas[r];
    }
}