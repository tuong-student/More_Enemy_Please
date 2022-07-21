using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour, IDamageable
{
    #region Components
    [Header("Scripts")]
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerScript playerScript;
    #endregion

    #region Stats
    #endregion

    #region Damage
    public void Damage(float damage)
    {
        playerScript._currentHealth -= damage;
    }

    public void PushBack(Vector3 direction){
        
    }
    #endregion
}
