using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform player;

    public float acceleration;
    public float maxSpeed;

    private bool alive = true;

    public NavMeshAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        SetRigidBodies(true);
        SetColliders(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            transform.LookAt(player);
            agent.SetDestination(player.position);
        }
    }


    public void Death()
    {
        agent.enabled = false;

        SetRigidBodies(false);
        SetColliders(true);
        GetComponentInChildren<Animator>().enabled = false;


        alive = false;
        Destroy(gameObject, 5);
    }

    void SetRigidBodies(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            if (!rigidbody.gameObject.CompareTag("Enemy"))
            {
                rigidbody.isKinematic = state;
            }
            
        }
    }

    void SetColliders(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            if (!collider.gameObject.CompareTag("Enemy"))
            {
                collider.enabled = state;
            }
            else
            {
                collider.enabled = !state;
            }
        }
    }

}
