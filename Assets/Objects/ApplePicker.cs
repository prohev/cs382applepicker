using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {

	public GameObject basketPrefab;
	public GameObject restartButton;
	private int numBaskets = 4;
	private float basketBottomY = -14f;
	private float basketSpacingY = 2f;

	public List<GameObject> basketList;
	public Text roundText;

	// Use this for initialization
	void Start () {
		basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++ ) {
			GameObject tBasketGO = Instantiate( basketPrefab ) as GameObject;
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + ( basketSpacingY *i );
			tBasketGO.transform.position = pos;
			basketList.Add( tBasketGO );
		}

		GameObject scoreGO = GameObject.Find("RoundCounter");
		roundText = scoreGO.GetComponent<Text>();
		roundText.text = "Round 1";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AppleDestroyed() {
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
		foreach ( GameObject tGO in tAppleArray ) {
			Destroy(tGO);
		}

		int basketIndex = basketList.Count-1;
		GameObject tBasketGO = basketList[basketIndex];
		basketList.RemoveAt( basketIndex );
		Destroy( tBasketGO );

		if (basketList.Count == 0) {
			roundText.text = "Game Over";
			restartButton.SetActive(true);
		} 
		else {
			int round = numBaskets - basketList.Count + 1;
			roundText.text = "Round " + round;
		}
	}

	public void GameOver() {
    roundText.text = "Game Over";
    restartButton.SetActive(true);

	// destroying apples
    GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
    foreach (GameObject apple in apples) {
        Destroy(apple);
    }
    GameObject[] evilApples = GameObject.FindGameObjectsWithTag("EvilApple");
    foreach (GameObject evilApple in evilApples) {
        Destroy(evilApple);
    }

	// destroying remaining baskets
    foreach (GameObject basket in basketList) {
        Destroy(basket);
    }
    basketList.Clear();
}

	public void RestartGame() {
    	SceneManager.LoadScene("_Scene_0");
	}
}
