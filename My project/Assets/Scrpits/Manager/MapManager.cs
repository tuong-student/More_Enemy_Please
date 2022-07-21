using System.Runtime.CompilerServices;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    #region Components
    EnemyScript Enemy;
    Transform playerTransform;
    #endregion

    #region Stats
    [SerializeField] float radiusAroundPlayer = 1;

    #endregion

    void Awake()
    {
        Enemy = Resources.Load<EnemyScript>("Prefabs/View/Enemy");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateEnemy());
    }

    IEnumerator CreateEnemy(){
        while(true){
            yield return new WaitForSeconds(2f);
            if(playerTransform != null){
                Vector3 position = NOOD.NoodyCustomCode.GetPointAroundAPosition2D(playerTransform.position, radiusAroundPlayer);
                EnemyData enemyData = EnemyDataMaster.GetRandomData();
                EnemyScript enemyScript = Instantiate(Enemy, position, Enemy.transform.rotation);
                enemyScript.SetData(enemyData);
            }
        }
    }
}
