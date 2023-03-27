using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
   public GameObject bulletObj;
    public Transform firePoint;
    public float fireForce = 20f;
    public int weaponType = 1;
    public int bulletCount = 8;
    private bool reloading = false;
    private int reloadTimer = 50;
    // Start is called before the first frame update

    void Awake()
    {
        if(weaponType == 1)
        {
            bulletCount = 8;
        }
    }

    void FixedUpdate()
    {
        if(reloading && reloadTimer > 0)
        {
            reloadTimer -= 1;
        }
        else if(reloadTimer <= 0)
        {
            bulletCount = 8;
            reloading = false;
            reloadTimer = 50;
        }
        else if(!reloading && bulletCount == 0)
        {
            this.Reload();
        }
    }
    public void Fire()
    {
        if(reloading)
        {
            return;
        }
        
        if(weaponType == 1 && bulletCount > 0 && reloadTimer == 50)
        {
            GameObject bullet = Instantiate(bulletObj, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);

            bulletCount -= 1;
        }
    }

    public void Reload()
    {
        if(weaponType == 1 && bulletCount < 8)
        {
            reloading = true;
        }
    }

}
