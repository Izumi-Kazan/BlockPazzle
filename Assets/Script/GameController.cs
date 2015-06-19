using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	// UI
	public Text clearText;
	public Text faildedText;
	
	// ステージ終了フラグ
	private bool isStageEnd;

	void StageClear () {
		clearText.gameObject.SetActive( true );
		isStageEnd = true;
	}
	
	void StageFailed () {
		faildedText.gameObject.SetActive( true );
		isStageEnd = true;
	}
	
	void Start() {
		isStageEnd = false;
	}
	
	public void SelectedScene ( string scene ) {
		Application.LoadLevel( scene );
	}
	
	void Update () {
		// ステージが終了していてマウスの左クリックかタッチパネルが押されたら、シーンを読み込む
		if ( isStageEnd && (Input.GetKey(KeyCode.Mouse0)) || Input.touchCount > 0 ) Application.LoadLevel("Menu");
	}
}
