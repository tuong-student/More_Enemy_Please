using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Components
    Transform targetTransform;
    [SerializeField] string targetTag;
    #endregion

    #region Stats
    [SerializeField] float smoothTime;
    [SerializeField] Vector3 offset;
    [SerializeField] float maxX, minX, maxY, minY;
    #endregion

    void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag(targetTag).transform;
    }

    void FixedUpdate()
    {
        NOOD.NoodyCustomCode.SmoothCameraFollow(this.gameObject, smoothTime, targetTransform, offset, maxX, maxY, minX, minY);
    }
}
