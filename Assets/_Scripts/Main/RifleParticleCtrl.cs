using UnityEngine;
using System.Collections;

public class RifleParticleCtrl : MonoBehaviour {
	/*
	 * Merkis ir iznicinat pasreizejo objektu, lai atriritu operativo atminu un heirarhiju
	 */
	
	//MonoBehaviour f-ja, kas tiek izsaukta, kad objekts tiek izveidots
	void Awake(){
		//iznicinam pasreizejo objektu pec 1.5 sekundem, lai attiritu Operativo atminu
		Destroy(gameObject,1.5f);
	}
}
