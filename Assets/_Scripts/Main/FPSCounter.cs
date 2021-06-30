using UnityEngine;
using System.Collections;

public class FPSCounter : MonoBehaviour {
	/*
	 * Klases merkis ir attelot speles veikstspeju, kas paradita ar skaitli, kas satur cik viena sekunde tiek kadri izpilditi
	 * Optimalais skaitlis ir augstak par 25 kadriem sekundé
	 */
	GUISkin gSkin;
	int yPos=5;
	int wide=29;
	int high =20;
	float fps;
	
	//MonoBehaviour f-ja, kas tiek izpildita ainai uzsakoties
	void Start(){
		gSkin = Resources.Load("gSkin",typeof(GUISkin)) as GUISkin;	
	}
	//MonoBehaviour f-ja, kas tiek izsaukta katru reizi, kad tiek izpildíts viens kadrs
	void Update () {
		//
		fps = 1.0f / Time.smoothDeltaTime;
	}
	//MonoBehaviour f-ja, kas tiek izsaukta katru reizi parzimejot GUI elementus
	void OnGUI(){
		//Noradam visiem GUI elementiem stila failu
		GUI.skin = gSkin;
		//Izveidojam tekstu, kam norádam dinamisku poziciju, kuram noradam tekstu fps.ToString()
		GUI.Label(new Rect(Screen.width - wide, yPos, wide, high), fps.ToString());
	}
}
