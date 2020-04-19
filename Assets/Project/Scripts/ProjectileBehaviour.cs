using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage;
    public float range;
    private float distanceTravelled;
    public float travelSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += this.gameObject.transform.forward * Time.deltaTime * travelSpeed;
        distanceTravelled += travelSpeed * Time.deltaTime;

        if (distanceTravelled >= range)
        {
            IsDestroyed();
        }   
    }

    public void IsDestroyed()
    {
        //Any cool destruction effect
        Destroy(this.gameObject);
    }
}
