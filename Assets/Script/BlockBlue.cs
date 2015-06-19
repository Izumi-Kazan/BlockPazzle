using UnityEngine;
using System.Collections;

/**<summary>

</summayr>*/
public class BlockBlue : MonoBehaviour {
	
	// 回転速度
	public float rotationSpeed = 60.0f;
	
	// 回転フラグ
	private bool isRotate = false;
	
	void OnMouseDown () {
		if ( isRotate ) return;
		//
		isRotate = true;
		// コールチン開始
		StartCoroutine ( RotateDestroy() );
	}

	IEnumerator RotateDestroy () {
		float angle = 0;
		while ( angle < 90 ) {
			angle += rotationSpeed * Time.deltaTime;
			transform.Rotate( 0, angle, 0 );
			yield return null;
		}
		Destroy ( gameObject );
	}
}
