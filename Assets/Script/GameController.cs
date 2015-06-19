using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	// UI
	public Text clearText;
	public Text faildedText;

	void StageClear () {
		clearText.gameObject.SetActive( true );
	}
	
	void StageFailed () {
		faildedText.gameObject.SetActive( true );
	}
}
