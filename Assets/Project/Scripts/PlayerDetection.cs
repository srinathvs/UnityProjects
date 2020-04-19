using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ReconType
{
    patrol,
    oversee,
    standground
}
public class PlayerDetection : MonoBehaviour
{
    bool playerFound;
    private GameObject playerObject;
    public float moveSpeed;
    public int damage=20;
    public int hp=1;
    public ReconType type;
    private float rotationspeed;
    public GameObject startPatrolPoint;
    public GameObject endPatrolPoint;
    public SpawnBehaviour Controller;
    public bool collided;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        if (!playerFound && type==ReconType.oversee)
        {
            this.gameObject.transform.Rotate(0, rotationspeed * Time.deltaTime, 0);
        }else if(!playerFound && type == ReconType.patrol)
        {
            this.gameObject.transform.LookAt(endPatrolPoint.transform);
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, endPatrolPoint.transform.position, moveSpeed * Time.deltaTime);
                if (Vector3.Distance(this.gameObject.transform.position, endPatrolPoint.transform.position) <= .1f)
                {

                    endPatrolPoint.transform.position = startPatrolPoint.transform.position;
                    startPatrolPoint.transform.position = this.gameObject.transform.position;
                }
        }
        if (playerFound)
        {
            if(playerObject!=null)
            this.gameObject.transform.LookAt(playerObject.transform);
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, playerObject.transform.position, moveSpeed*Time.deltaTime);

        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            playerObject=other.gameObject;
            playerFound = true;
        }
    }


    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            playerObject = other.gameObject;
            playerFound = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Leave player alone
            playerFound = false;
            playerObject = null;
            
        }
    }

    public void dealDamage(GameObject playerObject)
    {
        //Reduce damage from player's HP.
    }

    public void SetType(int num)
    {
        if (num == 0)
        {
            type = ReconType.oversee;
        }else if (num == 1)
        {
            type = ReconType.patrol;
        }
        else
        {
            type = ReconType.standground;
        }
    }

    public void SetMoveSpeed(float val)
    {
        moveSpeed = val;
    }

    public void SetrotationSpeed(float val)
    {
        rotationspeed = val;
    }

    public void setHealth(int val)
    {
        hp = val;
    }

    public void setDamage(int val)
    {
        damage = val;
    }

   
    public void setSpawndetector(SpawnBehaviour sb)
    {
        Controller = sb;
    }

    public void SetStartEndObject(GameObject start,GameObject end)
    {
        startPatrolPoint = start;
        endPatrolPoint = end;
    }

    public void isDestroyed()
    {
        Destroy(startPatrolPoint);
        Destroy(endPatrolPoint);
        Controller.spawnDestroyed();
        Controller.createSpawn();
        Destroy(this.gameObject);
    }
}
