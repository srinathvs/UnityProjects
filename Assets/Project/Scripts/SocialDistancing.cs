using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialDistancing : MonoBehaviour
{
    string exTag;
    public Shooter cancer;
    private float supplyDespawnTime=60f;
    private float currenttime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currenttime = supplyDespawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        currenttime -= Time.deltaTime;
        if (currenttime <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        exTag = other.gameObject.tag;
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<HealthController>().ResetHP();
            other.gameObject.GetComponentInParent<Shooter>().Reload();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.tag = this.gameObject.tag;
            other.gameObject.GetComponentInParent<HealthController>().ResetHP();
            other.gameObject.GetComponentInParent<Shooter>().Reload();
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.tag = exTag;
    }
}
