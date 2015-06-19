using UnityEngine;
using UnityEngine.UI;
//  using System.Collections;

/**<summary>
uGUIのテキストをブリングする。
gameObjectの様にはブリングできないため
</summary>*/
public class BringUIText : MonoBehaviour {
	
	// アタッチしたText自身
	private Text textField;
	
	// 点滅間隔の設定
	[SerializeField, RangeAttribute(1, 25)]
	int step = 1;
	
	// 最も透明の部分の透明度を設定
	[SerializeField, RangeAttribute(0, 192)]
	public int offsetAlpha = 0;
	
	float radianBase = Mathf.PI / 180;
	
	int alpha = 255;
	
	int counter = 0;
	
	Color32 currentColor;
	
	Color32[] alphaTable = new Color32[180];

	// コストの高いsinの計算を予め行って、配列に格納しておく
	void Start () {		
		// カレント Text UIを取得：これを使って、透明度を変更する
		textField = GetComponent<Text>();
		
		// 現状の色を運び屋に渡しておく:uGUIのテキストは直接 rgba にアクセスできないので
		currentColor = textField.color;
		
		// sinを 0 〜 179 まで計算
		for ( int i = 0; i < 180; i++ ) {
			// 0 〜 1 〜 0 までのsinの変化値を 255 にかけて、透明度の増減を求める
			float value = (alpha - offsetAlpha) * Mathf.Sin( i * radianBase );
			// 仲買業者に一旦預ける
			currentColor.a = (byte)( ((int)value) + offsetAlpha );
			// 上の答えを配列に収める
			alphaTable[i] = currentColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		// int型の上限値に近くなったら強制的にリセット
		if ( counter > 2147483071 ) counter = 0;
		// 予め計算された配列を使って、透明度を変化させる
		int indx = counter%180;
		// 透明度をアサイン
		textField.color = alphaTable[indx];
		// カウンターを進める：stepの変化値で点滅の調整が出来る
		counter += step;
	}
}
