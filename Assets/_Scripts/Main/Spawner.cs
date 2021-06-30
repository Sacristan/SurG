using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	/*
	 * Klases merkis ir radit pretiniekus atkariba no speletaja pozicijas
	 */
	
	float spawnRate = 3.5f;
	int radius = 75;
	
	//MonoBehavior f-ja, kas tiek izsaukta palaizot ainu
	void Start(){
		//MonoBehavior metode, kas rada rutínu, kas izsauc norádíto funciju pec x sekundem pirmo reizi un tad izsauc to
		//ik pec x sekundem 
		InvokeRepeating("Spawn",spawnRate,spawnRate);
	}
	//f-ja, kas rada pretiniekus relativi pret speletaja poziciju
	void Spawn(){
		//iegustam speletaja pasaules (globalo) X poziciju
		float plXPos=GameData.playerTr.position.x;
		//iegustam speletaja pasaules (globalo) Z poziciju
		float plZPos=GameData.playerTr.position.z;
		
		//deklarejam un inicializejam Vector3 objektu, kas  ir generets skaitlis + speletaja X globala pozicija,
		//kaa objekta X globala pozicija, generets skaitlis kaa objekta globala Y pozicija un z objekta globala pozicija lidzigi ka X 
		Vector3 spawnPos = new Vector3(Random.Range(-radius,radius)+plXPos,Random.Range(.0f,radius),Random.Range(-radius,radius)+plZPos);
		//objekts ko radít
		Transform objectToSpawn = Resources.Load("Prefabs/zombie",typeof(Transform)) as Transform;
		//izveidojam objektu pozicijaa ar nokluseeto rotaciju
		Instantiate(objectToSpawn,spawnPos,Quaternion.identity);
	}
}
