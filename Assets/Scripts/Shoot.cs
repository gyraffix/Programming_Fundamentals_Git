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
        Debug.DrawRay(origin.position, origin.forward * 50f, Color.red, 2f);
        RaycastHit hit;
        if (Physics.Raycast(origin.position, origin.forward, out hit, 50))
        {
            Debug.Log(hit.transform.gameObject.name);

            Enemy enemy = hit.transform.GetComponentInParent<Enemy>();
            Debug.Log($"Hit {hit.transform.name}, Enemy in parent: {hit.transform.GetComponentInParent<Enemy>()}");

            if (enemy != null)
            {
                enemy.Death();
                    
            }  
        }
    }


}
