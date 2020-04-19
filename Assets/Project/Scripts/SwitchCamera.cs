using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour
{

	public Camera camera1;
	public Camera camera2;
	public KeyCode map;
	public bool mapCheck;

	void Start()
	{
		camera1.enabled = true;
		camera2.enabled = false;
		mapCheck = false;
	}

	void Update()
	{
		if (!mapCheck)
		{
			if (Input.GetKey(map))
			{
				mapCheck = true;
				camera1.enabled = false;
				camera2.enabled = true;
				
			}
		}
		else
		{


			if (Input.GetKeyUp(map))
			{
				mapCheck = false;
				camera1.enabled = true;
				camera2.enabled = false;
			}
		}
	}
}