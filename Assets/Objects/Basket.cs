using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Basket : MonoBehaviour {

	public Text scoreGT;
	private int score = 0;

	//  initialization
	void Start () {
		GameObject scoreGO = GameObject.Find("ScoreCounter");
		scoreGT = scoreGO.GetComponent<Text>();
		scoreGT.text = "Score: 0";
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
	}

	void OnCollisionEnter( Collision coll ) {
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.CompareTag("EvilApple")){
			Destroy(collidedWith);
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
    		apScript.GameOver();
			return;
    	}

		if (collidedWith.CompareTag("Apple")){
			Destroy(collidedWith);

			score += 100;
			scoreGT.text = score.ToString();

			if (score > HighScore.score)
			{
				HighScore.score = score;
			}
		}
	}
}
