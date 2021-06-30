using UnityEngine;
using System.Collections;

public enum AIState{
	/*
	 * enumeratora jéga ir norádít AI statusu, kas izraisa konkrétu darbíbu vai bezdarbibu
	 */
	
	Idle,
	Following,
	Attacking,
	Dying
}

public class AI : MonoBehaviour {
	/*
	 * Klases uzdevums ir realizét pretinieku kontroli, t.i sekośanu spélétájam, kaitéjuma nodarísanu 
	 */
	float speed = .25f;
	Transform playerTr;
	Vector3 rotCorrection = new Vector3(0,90,0);
	
	float hp =100.0f;
	AIState aiState = AIState.Following;
	Transform tr;
	
	//MonoBehaviour f-ja, kas tiek izpildita ainai uzsakoties
	void Start(){
		//iekeśojam transform komponenti
		tr = transform;
	}
	//MonoBehaviour f-ja, kas tiek izsaukta reizi, tad kad jau ir ticis izpildits kadrs, tacu nakamais vel nav sacies
	void LateUpdate () {
		//iegustam speletaja parametrus (transform komponente)
		playerTr = GameData.playerTr;
		//iegustam attalumu no objekta pozicijas lidz speletaja pozicijai
		float dist = Vector3.Distance(tr.position,playerTr.position);
		
		//if(dist>100&&aiState!=AIState.Dying) aiState = AIState.Idle;
		
		//parbaudam vai objekts "nemirst"
		if(aiState!=AIState.Dying){
			//atkaribaa no attaluma noradam kaadaa stavoklii ir objekts (AIState)
			if(dist>100) aiState = AIState.Following;
			else if(dist>5) aiState = AIState.Following;
			else if(dist<=5) aiState = AIState.Attacking;
		}
		
		switch(aiState){
			case AIState.Idle:
				//print ("Neko nedaru!");
				//pagaidaam nav vajadzigs
				break;
			
			case AIState.Following:
				//noraadam, ka objekts kusteesies plustosi no savas koordinatas uz speletaja koordinati noradita laikaa
				tr.position = Vector3.Lerp(tr.position, playerTr.position, Time.deltaTime*speed);
				//noraadam, ka objektam ir jaskataas uz poziciju, kur x un z asis ir speletaja pozicijas x,z asis, bet y 
				//ir objekta pozicijas y ass
				tr.LookAt(new Vector3(playerTr.position.x,tr.position.y,playerTr.position.z));
				//korigejam rotaciju objektam, lai "seja" butu uz speletaja pusi
				tr.eulerAngles=tr.eulerAngles+rotCorrection;
				break;
			
			case AIState.Attacking:
				//parsejam dzivibu tekstu uz int, tad aprekinam dzivibas un nomainam dzivibu tekstu
				int hp = System.Int32.Parse(GameData.hpTxtMesh.text);
				GameData.hpTxtMesh.text = (hp-Mathf.RoundToInt(Time.timeSinceLevelLoad/20)).ToString();
				break;
				
			case AIState.Dying:
				//print (gameObject.name+"-> Mirst!");
				//pagaidaam nav vajadzigs
				break;
		}
	}
	//f-ja, kas tiek izsaukta, tad, kad objektam zino, ka savins ir izgajis tam cauri, kur ir nodots ari bojajums
	void OnDamage(float dmg){
		//parbaudam vai cietas fizikas komponente ir pievienota objektam
		if(rigidbody){
			//cietajai fizikai pievienojam impulsu ar virzienu, kas ir galvenas kameras lokalas z ass virziens
			rigidbody.AddForce(GameData.mainCameraGO.transform.forward,ForceMode.Impulse);
			//nonemam objektam dzivibas
			hp-=dmg;
			
			//ja dzivibas ir zemakas par 0
			if(hp<=0){
				//cietajai fizikai pievienojam rotacijas impulsa tipa speeku pa x ass pozitivo virzienu
				rigidbody.AddTorque (Vector3.right * 10,ForceMode.Impulse);
				//noradam, ka objekts "mirst"
				aiState = AIState.Dying;
				//noraadam, ka objekts ir jaiznicina pec 3 sekundeem, lai attiritu operativo atminu
				Destroy (gameObject,3.0f);
			}
		}
	}
}	
