using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public Transform origin;
    public Animator gunAnimator;
    public ParticleSystem muzzle;

    public int maxAmmo = 6;
    public float reloadTime;
    public Slider ammoSlider;

    private bool reloading = false;
    private int ammo;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameManager.instance;
        ammo = maxAmmo;
        ammoSlider.value = ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo <= 0)
            {
                Reload();
            }
            else
            {
                Fire();
                ammo--;
                ammoSlider.value = ammo;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload(); 
        }
    }

    private void Fire()
    {
        Debug.DrawRay(origin.position, origin.forward * 50f, Color.red, 2f);
        RaycastHit hit;

        gunAnimator.SetTrigger("Shot");
        muzzle.Play();
        if (Physics.Raycast(origin.position, origin.forward, out hit, 50))
        {
            Debug.Log(hit.transform.gameObject.name);

            Enemy enemy = hit.transform.GetComponentInParent<Enemy>();
            Debug.Log($"Hit {hit.transform.name}, Enemy in parent: {hit.transform.GetComponentInParent<Enemy>()}");
            
            if (enemy != null && enemy.alive)
            {
                enemy.Death();
                gameManager.UpdateScore(enemy.points);    
            }  
        }
    }

    public void Reload()
    {
        if (!reloading)
        {
            gunAnimator.SetTrigger("Reload");
            StartCoroutine(ReloadTimer());
        }
    }


    IEnumerator ReloadTimer()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadTime);

        reloading = false;
        ammo = maxAmmo;
        ammoSlider.value = ammo;
    }

}
