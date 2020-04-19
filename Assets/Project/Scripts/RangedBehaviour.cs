using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform CastPoint;
    public float FireTime;
    private float currentTime;
    public GameObject bullet;
    void Start()
    {
        currentTime = FireTime;
        StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {

        this.gameObject.transform.Rotate(2f, 0, 0);
      
    }

    public IEnumerator FireBullet()
    {
        while (true)
        {
            Instantiate(bullet, CastPoint.position, CastPoint.rotation);
            yield return new WaitForSeconds(FireTime);
        }
    }
}
