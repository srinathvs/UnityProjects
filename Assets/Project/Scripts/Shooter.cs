using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Shooter.cs - Script to give behavior to shooting the water gun and its projectiles.
/// </summary>
public class Shooter : MonoBehaviour
{
    /// <summary>
    /// Bullet projetile to be spawned
    /// </summary>
    public GameObject Bullet;

    /// <summary>
    /// Total ammo in the bag
    /// </summary>
    public float Ammo;

    /// <summary>
    /// Spawn location in front of the gun barrel
    /// </summary>
    public GameObject SpawnPoint;

    /// <summary>
    /// Ammo Object to reduce in size visually.
    /// </summary>
    public GameObject Ammoobj;

    /// <summary>
    /// speed of the projectile.
    /// </summary>
    public float speed;

    /// <summary>
    /// initial scale of the ammo object.
    /// </summary>
    private Vector3 init_scale;

    private float MaxAmmo=100;

    // Start is called before the first frame update
    void Start()
    {
        init_scale = Ammoobj.transform.localScale;  // save the original scale.
    }

    // Update is called once per frame
    void Update()
    {
        // If there is ammo then fire on mouse click
        if (Ammo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireBullet();
            }
        }
        else
        {
            Ammoobj.SetActive(false);
            Debug.Log("No Ammo!!");
        }

    }

    /// <summary>
    /// Instantiate the bullet projectile while there is ammo
    /// </summary>
    void FireBullet()
    {
        var Projectile = Instantiate(Bullet, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
        Projectile.GetComponent<Rigidbody>().AddForce(speed * Projectile.transform.forward);
        DecreaseAmmo();
    }

    /// <summary>
    ///  Decrease the Ammo count and reduce the size of the ammo visible on screen
    /// </summary>
    void DecreaseAmmo()
    {
        Ammo--;
        Ammoobj.transform.localScale = init_scale * Ammo / MaxAmmo;
    }

    /// <summary>
    /// Refresh the gun with new Ammo
    /// </summary>
    public void Reload()
    {
        Ammo = MaxAmmo;
        Ammoobj.transform.localScale = init_scale;
    }
}
