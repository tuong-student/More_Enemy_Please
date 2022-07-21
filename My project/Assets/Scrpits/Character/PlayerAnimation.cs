using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Components
    [Header("Scripts")]
    [SerializeField] PlayerScript playerScript;
    [SerializeField] PlayerCollision playerCollision;
    #endregion

    #region Stats
    #endregion

    public IEnumerator AnimationScalePlayer(float scaleX, float scaleY, float animationTime)
        {
            Vector3 originalSize = this.transform.localScale;
            Vector3 newSize = new Vector3(scaleX, scaleY, originalSize.z);
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / animationTime;
                this.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
                yield return null;
            }
            t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / animationTime;
                this.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
                yield return null;
            }
        }
}
