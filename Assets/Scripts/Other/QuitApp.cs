using UnityEngine;
using System.Collections;

public class QuitApp : MonoBehaviour 
{	
	void Update () 
	{
		if (Input.GetKey(KeyCode.Escape)) 
		{
				Application.Quit();
		}
	}
}
