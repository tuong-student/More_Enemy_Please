using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerScript : MonoBehaviour, IDamageable
{
    Vector2 movement;
    Rigidbody2D myBody;

    #region Component
    [Header("Component")]
    public GameObject Player;
    public ParticleSystem dust;
    public GameObject Gun;
    Transform gunTransform;
    GunScript gunScript;
    Camera cam;
    #endregion

    #region Movement
    [Header("Movement")]
    float currentSpeed;
    public float moveSpeed;
    public float dashSpeed;
    public float dashTime = 1f;     //How long you can dash
    public float dashRecoverTime = 2f;   //Dash need time to recover for avoid spaming
    float nextDashTime;    //Time for the next dash
    #endregion

    #region Stats
    [Header("Stats")]
    float maxHealth;
    float currentHealth;
    #endregion

    #region Scale animation
    public float scaleAnimationTime;
    public float scaleX, scaleY;
    #endregion

    void Awake()
    {
        cam = Camera.main;
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nextDashTime = Time.time;
        currentSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Gun)
        {
            gunTransform = Gun.transform;
            gunScript = Gun.GetComponent<GunScript>();
        }
        else
        {
            Debug.Log("No Gun");
        }

        Aimming();
        Shooting();
    }

    private void FixedUpdate()
    {
        Move();
    }

    #region Movement

        void Move()
        {
            if (Input.GetKey(KeyCode.LeftShift) && Time.time >= nextDashTime)
            {
                /*Dash: 
                 When press left shift and the current time is grater than the next allow dash time,
                current speed of the player will be increase in some second (dashTime). After perform dash, the current speed
                will be reset as normal speed*/
                nextDashTime += dashRecoverTime;
                CreateDust();
                currentSpeed = dashSpeed;
                StartCoroutine(AnimationScalePlayer(scaleX, scaleY, scaleAnimationTime));
                Invoke("SetNormalSpeed", dashTime);
            }


            myBody.velocity = movement * currentSpeed;
        }

        void SetNormalSpeed()
        {
            currentSpeed = moveSpeed;
        }

        IEnumerator AnimationScalePlayer(float scaleX, float scaleY, float animationTime)
        {
            Vector3 originalSize = this.transform.localScale;
            Vector3 newSize = new Vector3(scaleX, scaleY, originalSize.z);
            float t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / animationTime;
                Player.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
                yield return null;
            }
            t = 0f;
            while (t <= 1f)
            {
                t += Time.deltaTime / animationTime;
                Player.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
                yield return null;
            }
        }

        void CreateDust()
        {
            dust.Play();
        }
    #endregion

    #region Shooting
    void Aimming()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        gunTransform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    void Shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Gun)
            {
                ReCoil();
                gunScript.Shoot();
            }
        }
    }

    void ReCoil()
    {
        gunTransform.localPosition = new Vector3(-0.2f, 0f, 0f);
        gunTransform.localEulerAngles += new Vector3(0f, 0f, 10f);
        Invoke("DownCoil", 0.2f);
    }

    void DownCoil()
    {
        gunTransform.localPosition = Vector3.zero;
    }
    #endregion

    #region Damage
    public void Damage(float damage)
    {
        this.currentHealth -= damage;
    }
    #endregion
}
