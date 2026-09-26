using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
	static public int score = 1000;

	void Awake () {
		if ( PlayerPrefs.HasKey("ApplePickerHighScore") ) {
			score = PlayerPrefs.GetInt("ApplePickerHighScore");
		}
		PlayerPrefs.SetInt("ApplePickerHighScore", score);
	}

	// Use this for initialization
	void Start () {
		Text gt = this.GetComponent<Text>();
		gt.text = "High Score: " + score;
	}
	
	// Update is called once per frame
	void Update () {
		Text gt = this.GetComponent<Text>();

		if ( score > PlayerPrefs.GetInt("ApplePickerHighScore") ) {
			PlayerPrefs.SetInt("ApplePickerHighScore", score);
			gt.text = "High Score: " + score;
		}
	}
}
