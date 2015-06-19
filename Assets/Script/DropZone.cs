using UnityEngine;
using System.Collections;

public class DropZone : MonoBehaviour {
	
	//
	public GameObject gameController;
	
	/**<summary>
	トリガー設定したコリジョンに、他のコリジョンが衝突したとき
	</summary>*/
	void OnTriggerEnter ( Collider otherCollider ) {
		// 名前で判定：：緑ブロックがヒットしたらゲームコントローラーに失敗を通知
		if ( otherCollider.name == "BlockGreen" ) gameController.SendMessage( "StageFailed" );
		// ヒットしたオブジェクトを削除する
		Destroy ( otherCollider.gameObject );
	}
}
