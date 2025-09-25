using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform origin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(origin.position, origin.forward, out hit, 50))
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                hit.transform.gameObject.GetComponent<Enemy>().Death();
                    
            }  
        }
    }


}
