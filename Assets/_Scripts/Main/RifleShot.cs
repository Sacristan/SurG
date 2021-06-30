using UnityEngine;
using System.Collections;

public class RifleShot : MonoBehaviour {
	/*
	 * Klases nozīme ir kontrolēt neredzamos šāvīņus un izveidot sīkdaļiņu emmiterus 
	 */ 
	
	Transform tr;
	float lastShotTime;
	float distanceBetweenShots = 0.1f;
	
	//MonoBehaviour f-ja, kas tiek izpildita ainai uzsakoties
	void Start(){
		tr = transform;//kešojam transform komponenti, lai optimizētu veikstspēju
		lastShotTime = Time.time;//glabajam laiku, kad pedejo reizi ticis sauts
	}
	
	//MonoBehaviour f-ja, kas tiek izsaukta katru reizi, kad tiek izpildíts viens kadrs
	void Update () {
		//ja tiek piespiesta poga Fire1 un ja tagadejaa laika un pedeja savina laika starpiba
		//ir lielaka par noradito distanci starp saviniem un var saut, tad... 
		if(Input.GetButton("Fire1")&&(Time.time-lastShotTime>distanceBetweenShots)&&GameData.canShoot){
			//izveidojam lodi pasreizejaa objekta pozicija ar pasreizejaa objekta rotaciju
			Instantiate(Resources.Load("Prefabs/rifleBullet",typeof(Transform)),tr.position,tr.rotation);
			//izveidojam savina sikdalinas pasreizejaa objekta pozicija ar pasreizejaa objekta vecaka rotaciju un glabajam to mainigaja
			Transform obj = Instantiate(Resources.Load("Prefabs/riflePS",typeof(Transform)),tr.position,tr.parent.rotation) as Transform;
			//izveidotajai sikdalinai noradam pasreizeja objekta vecaaku kaa taa vecaaku
			obj.parent = tr.parent;
		}
	}
}
