using System.Linq.Expressions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using NOOD;

public class PlayerScript : MonoBehaviour
{
    Vector2 movement;
    Rigidbody2D myBody;

    #region Component
    [Header("Scripts")]
    [SerializeField] PlayerAnimation playerAnimation;
    [SerializeField] PlayerCollision playerCollision;
    [Header("Component")]
    public ParticleSystem dust;
    [SerializeField] Transform gunHolder;
    public GameObject Gun;
    public GameObject Gun2;
    Transform gunTransform;
    GunScript activeGun;
    Camera cam;
    PlayerInputSystem playerInputSystem;
    #endregion

    #region Movement
    [Header("Movement")]
    float currentSpeed;
    public float moveSpeed;
    public float dashSpeed;
    public float dashTime = 1f;     //How long you can dash
    public float dashRecoverTime = 2f;   //Dash need time to recover for avoid spamming
    float nextDashTime;    //Time for the next dash
    #endregion

    #region Stats
    [Header("Stats")]
    float maxHealth;
    float currentHealth;
    bool isDashing;
    #endregion

    #region Properties
    public float _currentHealth{get{return this.currentHealth;} set{this.currentHealth = value;}}
    #endregion

    #region Scale animation
    public float scaleAnimationTime;
    public float scaleX, scaleY;
    #endregion

    void Awake()
    {
        cam = Camera.main;
        myBody = GetComponent<Rigidbody2D>();
        playerInputSystem = new PlayerInputSystem();
    }

    // Start is called before the first frame update
    void Start()
    {
        activeGun = Gun.GetComponent<GunScript>();
        nextDashTime = Time.time;
        currentSpeed = moveSpeed;
        playerInputSystem.Enable();
        playerInputSystem.GunAction.Fire.performed += Shooting;
        playerInputSystem.GunAction.ChangeGun1.performed += ChangeGun1;
        playerInputSystem.GunAction.ChangeGun2.performed += ChangeGun2;
        playerInputSystem.Move.Dash.performed += Dash;

        if(Gun) {Gun.SetActive(true); }
        if(Gun2) {Gun2.SetActive(false); }
    }

    // Update is called once per frame
    void Update()
    {

        if(activeGun){
            Aiming();
        }
    }

    private void FixedUpdate()
    {
        Move(playerInputSystem.Move.Run.ReadValue<Vector2>());
        
        myBody.velocity = movement * currentSpeed;
    }

    #region Movement

        void Move(Vector2 inputVector)
        {
            movement = inputVector;
        }

        void Dash(InputAction.CallbackContext context){
            if (Time.time >= nextDashTime && !isDashing)
            {
                /*Dash: 
                 When press left shift and the current time is grater than the next allow dash time,
                current speed of the player will be increase in some second (dashTime). After perform dash, the current speed
                will be reset as normal speed*/
                nextDashTime += dashRecoverTime;
                isDashing = true;
                CreateDust();
                currentSpeed = dashSpeed;
                
                StartCoroutine(playerAnimation.AnimationScalePlayer(scaleX, scaleY, scaleAnimationTime));
                FunctionDelay.StartThreadDelayFunction(SetNormalSpeed, dashTime);
            }
        }

        void SetNormalSpeed()
        {
            currentSpeed = moveSpeed;
            isDashing = false;
        }

        

        void CreateDust()
        {
            dust.Play();
        }
    #endregion

    #region ChangeGun
    void ChangeGun1(InputAction.CallbackContext context){
        if(Gun){
            Gun.SetActive(true);
            Gun2.SetActive(false);
            activeGun = Gun.GetComponent<GunScript>();
        }
        if(activeGun == null){
            Debug.Log("No Gun 1");
        }
    }

    void ChangeGun2(InputAction.CallbackContext context)
    {
        if(Gun2){
            Gun.SetActive(false);
            Gun2.SetActive(true);
            activeGun = Gun2.GetComponent<GunScript>();
                
        }
        if(activeGun == null){
            Debug.Log("No Gun 2");
        }
    }
    #endregion

    #region Shooting
    void Aiming()
    {
        gunTransform = activeGun.gameObject.transform;
        Vector3 mousePosition = NoodyCustomCode.MouseToWorldPoint();
        NoodyCustomCode.LookToMouse2D(gunTransform);
    }

    void Shooting(InputAction.CallbackContext context)
    {
        if (activeGun && context.performed)
        {
            activeGun.Shoot();
            activeGun.ReCoil();
        }
        
    }

    
    #endregion

    
}
