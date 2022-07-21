using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCamera : MonoBehaviour
{
    #region Components
    #endregion

    #region Stats
    [SerializeField] float duration, magnitude;
    [SerializeField] float explodeMagnitude;
    #endregion

    public static CustomCamera InsCustomCamera;

    void Awake()
    {
        if(InsCustomCamera == null) InsCustomCamera = this;
    }
    
    public void Shake(){
        StartCoroutine(NOOD.NoodyCustomCode.CameraShake(this.gameObject, duration, magnitude));
    }

    public void ExplodeShake(){
        StartCoroutine(NOOD.NoodyCustomCode.CameraShake(this.gameObject, duration, explodeMagnitude));
    }
}
