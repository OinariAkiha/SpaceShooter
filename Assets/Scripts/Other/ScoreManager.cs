using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	public static int currentScore;
	public static int highScore;
	public Text scoreText;

	void Update()
	{
		scoreText.text = ("Score : " + currentScore);
	}
}
