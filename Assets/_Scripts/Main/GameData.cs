using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {
	/*
	 * Klases merkis ir glabat vajadzigos datus statiskajos publiskajost klases atributos, lai tas nebutu
	 * jadara atseviskiem objektiem pasiem, kas krietni uzlabo veiktspeju
	 */
	
	public static Transform playerTr;
	public static TextMesh hpTxtMesh;
	public static TextMesh ammoTxtMesh;
	public static TextMesh timeTxtMesh;
	public static GameObject mainCameraGO;
	public static bool canShoot=true;
	
	//MonoBehaviour f-ja, kas tiek izsaukta fiksetu skaitu reizu sekundé t.i. 1 reizi 0.22 ms
	void FixedUpdate () {
		//iegústam speletaja GameObject caur tagu un tad iegustam ta komponenti transform
		playerTr = GameObject.FindWithTag("Player").transform;
		//iegústam dzivibu teksta GameObject caur tagu un tad iegustam ta komponenti TextMesh
		hpTxtMesh = GameObject.FindWithTag("HP").GetComponent<TextMesh>();
		//iegústam municijas teksta GameObject caur tagu un tad iegustam ta komponenti TextMesh
		ammoTxtMesh = GameObject.FindWithTag("Ammo").GetComponent<TextMesh>();
		//iegústam laika teksta GameObject caur tagu un tad iegustam ta komponenti TextMesh
		timeTxtMesh = GameObject.FindWithTag("Time").GetComponent<TextMesh>();
		//iegustam galvenas kameras GameObjectu
		mainCameraGO = Camera.main.gameObject;
		
		//parseejam dzivibu tekstu int tipa mainigaja
		int hp = System.Int32.Parse(hpTxtMesh.text);
		//Parbaudam vai dzivibas nav zemakas par nulli
		if (hp<=0){
			//palaizam ainu nr. 2
			Application.LoadLevel(2);
		}
	}
	//Monobehaviour f-ja, kas tiek izsaukta, tad kad objekts tiek izveidots
	void Awake(){
		//norádam, ka kursors NEbus redzams logaa
		Screen.showCursor=false;	
	}
}
