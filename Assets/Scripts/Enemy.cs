using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody rb;
    private Transform player;

    public float acceleration;
    public float maxSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        rb.AddForce(transform.forward * acceleration, ForceMode.Force);

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

    }


    public void Death()
    {
        Destroy(gameObject);
    }
}
