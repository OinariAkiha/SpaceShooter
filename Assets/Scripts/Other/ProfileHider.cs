using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProfileHider : MonoBehaviour {

	string scene;
	public CanvasGroup profileCanvas;
	// Use this for initialization
	void Start () 
	{
		scene = SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (SceneManager.GetActiveScene ().name != scene) {
			profileCanvas.alpha = 0f;
		} else {
			profileCanvas.alpha = 1f;
		}
	}
}
