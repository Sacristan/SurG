using UnityEngine;
using System.Collections;

public class RifleShotCtrl : MonoBehaviour {
	/*
	 * Merkis ir lodes kustibas virziena, atruma un saskares ar citiem kolaideriem kontrole 
	 */
	
	float speed = 150.0f;
	float rifleDmg = 4.5f;
	Transform tr;
	
	//Monobehaviour f-ja, kas tiek izsaukta, tad kad objekts tiek izveidots
	void Awake(){
		//noradam to, ka objekts tiks iznicinats pec 1.5 sekundem (lai attiritu operativo atminu)
		Destroy(gameObject,1.5f);
		tr = transform;
	}
	//MonoBehaviour f-ja, kas tiek izsaukta katru reizi, kad tiek izpildíts viens kadrs
	void Update () {
		//glabajam vektoraa virzienu, kas ir galvenas kameras z lokalas asis pozitivais virziens 
		Vector3 direction = GameData.mainCameraGO.transform.forward;
		//izveidojam vektoru, kas iever virzienu reizinatu ar atrumu
		//un reizinatu ar skaitli, kas ir cik s tiek pavaditas viena kadra izpildei
		Vector3 tmpdir = direction * speed * Time.deltaTime;
		//pieskaitam to pasreizeja objekta pozicijai
		tr.position += tmpdir;
	}
	//MonoBehaviour f-ja, kas tiek izsaukta, tad kad pasreizejais objekts saskaraas ar cita objekta kolaideru
	void OnTriggerEnter(Collider other){
		//otram objektam nosutam "zinu", izsaucot ta funkciju OnDamage ar bojajuma parametru un
		//noradam, ka mums nav obligati vajadzigs sanemejs, t.i. komponente/skripts ar f-ju OnDamage
		other.gameObject.SendMessage("OnDamage",rifleDmg,SendMessageOptions.DontRequireReceiver);
	}
}
