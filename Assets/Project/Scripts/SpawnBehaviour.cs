using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public int maxSpawns;
    private int currentSpawns;
    private float spawnTime;
    public float consty;
    private float maxTime;
    public GameObject spawnObject;
    private GameObject currentSpawn;
    private PlayerDetection currentPD;
    public Transform bottombounds;
    public Transform topbounds;
    private bool spawning=true;
    private float gameTime;
    public float destroyTime=30f;
    private float respawnTime;
    private float time1=20f;
    private float time2=10f;
    private float time3=5f;
    private bool spawnKilled;
    // Start is called before the first frame update
    void Start()
    {
       
    }
        
    

    // Update is called once per frame
    void Update()
    {

        gameTime += Time.deltaTime;
        if (!spawnKilled && spawning)
        {
            createSpawn();
        }
        if (gameTime >= 150 && gameTime <300)
        {
            destroyTime = time1;
        }
        if(gameTime >= 300 && gameTime < 450)
        {
            destroyTime = time2;
        }
        if(gameTime >= 450)
        {
            destroyTime = time3;
        }
        if (spawnKilled)
        {
            respawnTime -= Time.deltaTime;
            if (respawnTime <= 0)
            {
                createSpawn();
                spawnKilled = false;
            }
            
            
        }
       
    }

    public void createSpawn()
    {
        if (spawning)
        {
            while (currentSpawns < maxSpawns)
            {
                
                currentSpawns++;
                var ms = Random.Range(10, 30);
                var rms = Random.Range(10, 30);
                var xpt = Random.Range(bottombounds.position.x, topbounds.position.x);
                var zpt = Random.Range(bottombounds.position.z, topbounds.position.z);
                var xpt1 = Random.Range(bottombounds.position.x, topbounds.position.x);
                var zpt1 = Random.Range(bottombounds.position.z, topbounds.position.z);


                Vector3 startpt = new Vector3(xpt, consty, zpt);
                Vector3 endpt = new Vector3(xpt1, consty, zpt1);
                var starter = new GameObject("starter");
                var ender = new GameObject("ender");
                starter.transform.position = startpt;
                ender.transform.position = endpt;
                starter.transform.SetParent(this.gameObject.transform);
                ender.transform.SetParent(this.gameObject.transform);
                int type = Random.Range(0, 2);
                currentSpawn = Instantiate(spawnObject, startpt, Quaternion.identity);
                currentSpawn.transform.position = startpt;
                currentPD = currentSpawn.GetComponent<PlayerDetection>();
                currentPD.SetStartEndObject(starter, ender);

                currentPD.SetMoveSpeed(ms);
                currentPD.SetType(type);
                currentPD.SetrotationSpeed(rms);
                currentPD.setDamage(20);
                currentPD.setHealth(1);
                currentPD.setSpawndetector(this.gameObject.GetComponent<SpawnBehaviour>());
                currentPD.transform.SetParent(this.gameObject.transform);
                currentPD.transform.localScale = new Vector3(1, 1, 1);
            }
            spawning = false;
        }
        else
        {
            if (currentSpawns < maxSpawns && spawnKilled==false)
            {

                
                currentSpawns++;
                var ms = Random.Range(10, 30);
                var rms = Random.Range(10, 30);
                var xpt = Random.Range(bottombounds.position.x, topbounds.position.x);
                var zpt = Random.Range(bottombounds.position.z, topbounds.position.z);
                var xpt1 = Random.Range(bottombounds.position.x, topbounds.position.x);
                var zpt1 = Random.Range(bottombounds.position.z, topbounds.position.z);


                Vector3 startpt = new Vector3(xpt, consty, zpt);
                Vector3 endpt = new Vector3(xpt1, consty, zpt1);
                var starter = new GameObject("starter");
                var ender = new GameObject("ender");
                starter.transform.position = startpt;
                ender.transform.position = endpt;
                starter.transform.SetParent(this.gameObject.transform);
                ender.transform.SetParent(this.gameObject.transform);
                int type = Random.Range(0, 2);
                currentSpawn = Instantiate(spawnObject, startpt, Quaternion.identity);
                currentSpawn.transform.position = startpt;
                currentPD = currentSpawn.GetComponent<PlayerDetection>();
                currentPD.SetStartEndObject(starter, ender);

                currentPD.SetMoveSpeed(ms);
                currentPD.SetType(type);
                currentPD.SetrotationSpeed(rms);
                currentPD.setDamage(20);
                currentPD.setHealth(1);
                currentPD.setSpawndetector(this.gameObject.GetComponent<SpawnBehaviour>());
                currentPD.transform.SetParent(this.gameObject.transform);
                currentPD.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void spawnDestroyed()
    {
        currentSpawns--;
        respawnTime = destroyTime;
        spawnKilled = true;
    }

}
