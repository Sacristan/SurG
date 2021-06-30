using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {
	/*
	 * Klases uzdevums ir izveidot pogu, kuru piespieźot tiek palaista spele
	 */
	
	GUISkin gSkin;
	
	//Monobehaviour f-ja, kas tiek izsaukta, tad kad objekts tiek izveidots
	void Awake(){
		//norádam, ka kursors bus redzams logaa
		Screen.showCursor = true; 
		//iegustam gSkin failu no Resursu mapes
		gSkin = Resources.Load("gSkin",typeof(GUISkin)) as GUISkin;
	}
	//MonoBehaviour f-ja, kas tiek izsaukta katru reizi parzimejot GUI elementus
	void OnGUI(){
		//Noradam visiem GUI elementiem stila failu
		GUI.skin = gSkin;
		
		//Ja tiek piespiesta poga, kurai tiek noradita pozicija un tad taas tekstiska vertiba
		if(GUI.Button(new Rect(Screen.width/2-50,Screen.height/2-12.5f,100,25),"Play SurG!")){
			//Ieladejam ainu 1
			Application.LoadLevel(1);
		}
	}
}
