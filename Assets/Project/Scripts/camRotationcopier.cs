using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camRotationcopier : MonoBehaviour
{
    public GameObject camPivot;
    private Quaternion noXrot;
    private float horizontalMouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMouse += Input.GetAxis("Mouse X");
        noXrot.eulerAngles = new Vector3(0, horizontalMouse, 0);
        noXrot.Normalize();
        this.gameObject.transform.rotation=noXrot;
    }
}
