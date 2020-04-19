using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float camDistance;
    public float camHeight;
    public float horizontalMouse;
    public float verticalMouse;
    public float clampAngle;
    public Transform characterTransform;
    public bool callOnce;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        camControl();
    }


    private void camControl()
    {
       
        this.gameObject.transform.position = new Vector3(characterTransform.position.x, characterTransform.position.y + camHeight, characterTransform.position.z);
       

        
        horizontalMouse += Input.GetAxis("Mouse X");
        verticalMouse += Input.GetAxis("Mouse Y");
        verticalMouse = Mathf.Clamp(verticalMouse, -clampAngle, clampAngle);


        this.gameObject.transform.rotation = Quaternion.Euler(verticalMouse, horizontalMouse, 0);
        
    }

    public void setPlayerPosition(Transform character)
    {
        characterTransform = character;
    }
}
