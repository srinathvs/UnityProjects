using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Common_Movement_Properties")]
    public Transform targetRot;
    public float rotSpeed;
    public float MoveSpeed;
    public float jumpForce;
    public GameObject camObject;
    public bool onGround;
    public bool canMove = true;


    [Header("Keycodes")]
    public KeyCode runKey;
    public KeyCode weaponKey;
    public KeyCode jumpKey;
    public KeyCode fireKey;


    [Header("Character_Specific_Properties")]
    public Animator playerAnimator;
    public Transform playerObject;

    [Header("Exposed_Properties")]
    public Vector3 direction;
    private Vector3 jumpdirection;
    public float horizontal;
    public float vertical;
    public bool jumped;

    public GameObject Weapon;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

        playerAnimator.SetBool("onGround", onGround);
        direction = (camObject.transform.right.normalized * horizontal) + (camObject.transform.forward.normalized * vertical);
        direction.y = 0;
        if (onGround)
        {
            if ((horizontal != 0 || vertical != 0))
            {

                playerAnimator.SetBool("moving", true);
                if (Input.GetKey(runKey))
                {
                    playerAnimator.SetBool("run", true);

                }
                else
                {
                    playerAnimator.SetBool("run", false);

                }

                if (Input.GetKeyDown(weaponKey))
                {

                    if (playerAnimator.GetBool("gunPose") == false)
                    {
                        Weapon.SetActive(true);

                        //Setting gun pose
                        playerAnimator.SetBool("gunPose", true);
                    }
                    else
                    {
                        Weapon.SetActive(false);
                        //reset gun pose
                        playerAnimator.SetBool("gunPose", false);
                    }
                }
                gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);
                if (!playerAnimator.GetBool("run"))
                { gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed, ForceMode.VelocityChange); }
                else
                {
                    gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed * 1.5f, ForceMode.VelocityChange);
                }
                if (canJump())
                {
                    jumpdirection = (this.gameObject.GetComponent<Rigidbody>().velocity + Vector3.up) * jumpForce;
                    if (Input.GetKeyDown(jumpKey))
                    {
                        playerAnimator.SetBool("jump", true);
                        gameObject.GetComponent<Rigidbody>().AddForce(jumpdirection, ForceMode.VelocityChange);

                    }
                }
            }
            else if (horizontal == 0 && vertical == 0)
            {
                playerAnimator.SetBool("moving", false);
                if (Input.GetKeyDown(weaponKey))
                {
                    if (playerAnimator.GetBool("gunPose") == false)
                    {
                        playerAnimator.SetBool("gunPose", true);
                        this.gameObject.transform.rotation = targetRot.rotation;

                    }
                    else
                    {
                        playerAnimator.SetBool("gunPose", false);
                    }
                }
                if (canShoot())
                {

                }

                if (canJump())
                {
                    jumpdirection = (this.gameObject.GetComponent<Rigidbody>().velocity + Vector3.up) * jumpForce;
                    if (Input.GetKeyDown(jumpKey))
                    {
                        playerAnimator.SetBool("jump", true);
                        gameObject.GetComponent<Rigidbody>().AddForce(jumpdirection, ForceMode.VelocityChange);

                    }
                }
            }
        }
        else
        {
            playerAnimator.SetBool("moving", false);
            playerAnimator.SetBool("run", false);
        }


    }

    public void forceWalk()
    {
        // gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed*20, ForceMode.VelocityChange);
    }

    public void forceRun()
    {
        // gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed * 40, ForceMode.VelocityChange);
    }

    public bool canJump()
    {
        if (onGround && !playerAnimator.GetBool("jump"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public bool canShoot()
    {
        return playerAnimator.GetBool("gunPose");
    }

    public void jumpStart()
    {

    }

    public void finishedJump()
    {
        playerAnimator.SetBool("jump", false);
    }
}
