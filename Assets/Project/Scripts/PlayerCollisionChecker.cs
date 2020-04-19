using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PlayerCollisionChecker.cs - Script to check if the Player is colliding with any objects.
/// Contains basic collision functions for all the objects in the environment.
/// </summary>
public class PlayerCollisionChecker : MonoBehaviour
{
    /// <summary>
    /// Current Health of the player
    /// </summary>
    public HealthController health;

    /// <summary>
    /// collided gameobject.
    /// </summary>
    private GameObject cObject;

    /// <summary>
    /// Player Detection script instance.
    /// </summary>
    private PlayerDetection PD;

    /// <summary>
    /// Projectile Behavior script instance.
    /// </summary>
    private ProjectileBehaviour PJB;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// On collision with the enemy then check object tag and match with enemy.
    /// </summary>
    /// <param name="collision"> Default collision component.
    /// </param>
    private void OnCollisionEnter(Collision collision)
    {

        // if an enemy is collided.
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // asssign the collided object to the current object. 
            cObject = collision.gameObject;
            // detect the player from the enemies side.
            PD = cObject.GetComponentInParent<PlayerDetection>();
            // reduce health.
            health.takeDamage(PD.damage);
            // Destroy the script component.
            PD.isDestroyed();
            PD = null;
            cObject = null;
        }

        // if collision is with an enemy projectile then take damage. 
        if (collision.gameObject.CompareTag("Projectile"))
        {
            cObject = collision.gameObject;
            PJB = cObject.GetComponentInParent<ProjectileBehaviour>();
            health.takeDamage(PJB.damage);
            PJB.IsDestroyed();
            PJB = null;
            cObject = null;

        }
    }

    /// <summary>
    /// Function that triggers when the player is continuing to collide with an enemy or a projectile
    /// </summary>
    /// <param name="collision">  Default collision component.
    /// </param>
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cObject = collision.gameObject;
            PD = cObject.GetComponentInParent<PlayerDetection>();
            health.takeDamage(PD.damage);
            Debug.Log("Collided with enemy, damage dealt is :" + cObject.name);
            PD.isDestroyed();

        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            cObject = collision.gameObject;
            PJB = cObject.GetComponentInParent<ProjectileBehaviour>();
            health.takeDamage(PJB.damage);
            PJB.IsDestroyed();
            PJB = null;
            cObject = null;
        }
    }

    /// <summary>
    /// Function for when collision stops on the enemy or projectile.
    /// </summary> 
    /// <param name="collision"> Default collision component.
    /// </param>
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            cObject = collision.gameObject;
            PD = cObject.GetComponentInParent<PlayerDetection>();
            health.takeDamage(PD.damage);
            Debug.Log("Collided with enemy, damage dealt is :" + cObject.name);
            PD.isDestroyed();

        }
        if (collision.gameObject.CompareTag("Projectile"))
        {
            cObject = collision.gameObject;
            PJB = cObject.GetComponentInParent<ProjectileBehaviour>();
            health.takeDamage(PJB.damage);
            PJB.IsDestroyed();
            PJB = null;
            cObject = null;
        }
    }
}
