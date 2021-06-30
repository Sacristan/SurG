using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour {
	/*
	 * Klases merkis ir nogaidit un tad ieladet Intro ainu
	 */
	
	//MonoBehaviour f-ja, kas tiek izpildita ainai uzsakoties
	void Start () {
		//izsaucam rutinu LoadIntro
		StartCoroutine(LoadIntro());
	}
	
	//IEnumerator f-ja, kas nogaida paris sekundes un ielade nakamo limeni
	IEnumerator LoadIntro(){
		//nogaida kamer atgriezas no WaitForSeconds
	 	yield return new WaitForSeconds(3.0f);
		//ieladee Intro Limeni
		Application.LoadLevel(0);
	}
}
