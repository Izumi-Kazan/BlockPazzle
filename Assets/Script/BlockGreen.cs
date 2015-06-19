using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BlockGreen : MonoBehaviour {
	
	// ブロック破壊エフェクト用オブジェクト
	public GameObject brokenBlocksPrefab;
	
	// ブロックの硬さ
	public float hardness = 5.0f;
	
	// ブロック停止を判断する移動量のしきい値
	public float stopDetectMagnitude = 0.1f;
	
	// ブロック停止を判断する時間
	public float stopDetectTime = 1.0f;
	
	// ブロック停止の判断中
	private bool isStopChecking = false;
	
	// ブロック停止時間
	private float stopTime;
	
	// ゲームコントローラ
	public GameObject gameController;
	
	private Rigidbody myRigidbody;
	
	void Start() {
		myRigidbody = GetComponent<Rigidbody>();
	}
	
	bool IsGround() {
		// Floorが属しているFloorレイヤーのレイヤーマスク:8がレイヤーマスクの番号と対応していないといけない：2進数で100000000になるから
		int layerMaskFloor = 1 << 8;
		// ブロックの下方向にレイを発射してヒットするかどうかデシジョン
		if ( Physics.Raycast ( transform.position, Vector3.down, GetComponent<Collider>().bounds.extents.y, layerMaskFloor ) ) return true;
		return false;
	}
	
	void Update () {
		// ブロックの移動速度がしきい値以下かチェック
		if ( myRigidbody.velocity.magnitude < stopDetectMagnitude ) {
			//
			if ( !isStopChecking ) {
				isStopChecking = true;
				// ブロックが停止した時間を記録　
				stopTime = Time.time;				
			}
			// 一定時間停止した状態で、Floorの上で停止しているかデシジョン：：GameControllerに成功を伝える
			if ( isStopChecking && ( Time.time - stopTime ) > stopDetectTime && IsGround() ) gameController.SendMessage( "StageClear" );
		}
	}
	
	
	/**<summary>
	他のColliderとぶつかった瞬間にコールされる
	</summayr>*/
	void OnCollisionEnter ( Collision collisionInfo ) {
		// ぶつかった相手の速度が硬さを上回るかチェック
		if ( collisionInfo.relativeVelocity.magnitude > hardness ) {
			// 破壊演出用オブジェクトをインスタンス化
			Instantiate( brokenBlocksPrefab, transform.position, brokenBlocksPrefab.transform.rotation );
			// オブジェクト削除
			Destroy ( gameObject );
			// ゲームコントローラに失敗を通知
			gameController.SendMessage( "StageFailed" );
		}
	}
}
