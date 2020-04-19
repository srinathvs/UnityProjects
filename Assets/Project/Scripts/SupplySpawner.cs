using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplySpawner : MonoBehaviour
{
    private float supplyTimer=60f;
    private float currenttimer = 0;
    public bool supplyavailable;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;
    public GameObject supply;
    // Start is called before the first frame update
    void Start()
    {
        currenttimer = supplyTimer;
        StartCoroutine(spawnSupplies());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public IEnumerator spawnSupplies()
    {
        while (true)
        {
            yield return new WaitForSeconds(60f);
            Instantiate(supply, new Vector3(pos1.transform.position.x, 10, pos1.transform.position.z), Quaternion.identity);
            Instantiate(supply, new Vector3(pos2.transform.position.x, 10, pos2.transform.position.z), Quaternion.identity);
            Instantiate(supply, new Vector3(pos3.transform.position.x, 10, pos3.transform.position.z), Quaternion.identity);
        }

    }
}
