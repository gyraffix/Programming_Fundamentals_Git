using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    static public PlayerController instance;

    private GameManager gameManager;
    

    //-------------Player Variables-----------------

    public Rigidbody rb;
    public int maxHealth = 3;
    public Slider healthSlider;
    public float pushbackForce;
    public Animator hitEffect;
   


    private int health;


    //==============================================


    //-------------Camera Variables-----------------

    public Transform anchor;
    public float cameraSens;
    public float minRotationX;
    public float maxRotationX;

    private float rotationX;

    //==============================================


    //-----------Movement Variables---------------

    public float speed;
    
    //============================================

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        rb = gameObject.GetComponent<Rigidbody>();
        gameManager = GameManager.instance;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
        Debug.Log(health);
    }
    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.AddRelativeForce
            (
            new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
                ) * speed,
            ForceMode.Force
            );

    }

    private void MoveCamera()
    {
        
        
        rotationX -= Input.mousePositionDelta.y * (cameraSens / 10);
        rotationX = Mathf.Clamp(rotationX, minRotationX, maxRotationX);


        //Rotate around the Y-axis
        transform.Rotate
            (
                0,
                Input.mousePositionDelta.x * (cameraSens/10),
                0
            );

        //Rotate around the X-axis
        anchor.localEulerAngles = new Vector3
            (
                rotationX,
                0,
                0
            );
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit by enemy");
            health--;
            healthSlider.value = health;
            hitEffect.SetTrigger("Hit");
        }
    }

}
