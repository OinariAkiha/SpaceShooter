using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

	public Text scoreText;

	void Start () 
	{
		ScoreManager.highScore = PlayerPrefs.GetInt ("HighScore");
		scoreText.text = ("High Score \n" + ScoreManager.highScore);
		Debug.Log (ScoreManager.highScore);
	}
}
