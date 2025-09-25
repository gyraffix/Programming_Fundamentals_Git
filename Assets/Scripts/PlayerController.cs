using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;

    //-------------Camera Variables-----------------

    public Transform anchor;

    public float cameraSens;

    private float rotationX;
    public float minRotationX;
    public float maxRotationX;
    
    
    //==============================================


    //-----------Movement Variables---------------
    
    public float speed;
    public float maxSpeed;
    
    //============================================

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //TODO: Move this into a GameManager Script
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        MoveCamera();
    }

    private void MovePlayer()
    {
        player.AddRelativeForce
            (
            new Vector3(
                Input.GetAxis("Horizontal"),
                0,
                Input.GetAxis("Vertical")
                ) * speed,
            ForceMode.Force
            );

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
        {
            player.linearVelocity = Vector3.zero;
        }


        if (player.linearVelocity.magnitude > maxSpeed)
        {
            player.linearVelocity = player.linearVelocity.normalized * maxSpeed;
        }

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

}
