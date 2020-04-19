using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public Animator playerAnimator;
    private float hitPoints = 100;
    private float hpDegradeTime = 5f;
    private float currentTime=30f;
    bool reduceHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0f && !reduceHP)
        {
            reduceHP = true;
            StartCoroutine(minusHp());
            currentTime = hpDegradeTime;
            reduceHP = false;
        }
        playerAnimator.SetFloat("hp", hitPoints);
    }
   
    public void takeDamage(int damage)
    {
        hitPoints -= damage;
    }

    public IEnumerator minusHp()
    {
        if (reduceHP)
        {
            hitPoints -= 1;
            yield return new WaitForSeconds(1f);
        }
    }

    public void ResetHP()
    {
        hitPoints = 100;
    }
}
