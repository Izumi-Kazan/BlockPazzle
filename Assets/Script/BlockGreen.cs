using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class BlockGreen : MonoBehaviour {
	
	// ブロック破壊エフェクト用オブジェクト
	public GameObject brokenBlocksPrefab;
	
	// ブロックの硬さ
	public float hardness = 5.0f;
	
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
		}
	}
}
