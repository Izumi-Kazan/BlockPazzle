using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	// クリック開始ポイント
	private Vector2 startPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float moveX = 0f;
		float moveY = 0f;
		// マウスクリック検出
		if ( Input.GetMouseButtonDown(0) ) {
			startPosition = Input.mousePosition;
		} else if ( Input.GetMouseButton(0) ) {
			moveX = (Input.mousePosition.x - startPosition.x) * 0.02f;
			moveY = (Input.mousePosition.y - startPosition.y) * 0.02f;
		} else if ( Input.GetMouseButtonUp(0) ) {
			startPosition = Vector2.zero;
		}
		
		// X軸の回転角度で、50度以上あるいは0度以下なら移動量を0に
		if ( (transform.rotation.eulerAngles.x - moveY >= 50) || (transform.rotation.eulerAngles.x - moveY <= 0) ) moveY = 0;
		
		// マウス上下（Y軸の移動量になる）でX軸回転
		transform.Rotate( -moveY, 0, 0 );
		
		// マウス左右（X軸の移動量になる）でグローバル座標のY軸回転
		transform.Rotate( 0, moveX, 0, Space.World );
	}
}
