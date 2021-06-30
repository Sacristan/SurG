using UnityEngine;
using System.Collections;

[System.Serializable]
public class Timer{
	/*
	 * klases merkis ir glabat minutes un sekundes
	 */
	public int minutes;
	public int seconds;
	
	//konstruktors
	public Timer(int p1, int p2){
		minutes = p1;
		seconds = p2;
	}
}

public class TimeCtrl : MonoBehaviour {
	/*
	 * Klases merkis ir nodrosinat veiksmigu 
	 */
	public Timer timer = new Timer(2,5);
	TextMesh textMesh;
	
	//MonoBehaviour f-ja, kas tiek izpildita ainai uzsakoties
	void Start () {
		//glabajam komponenti TextMesh
		textMesh = GetComponent<TextMesh>();
		
		//kamer sekundes ir vairak ka 59, tikmer...
		while(timer.seconds>59){
			timer.minutes++;
			timer.seconds-=60;	
		}
		//nodrosinam, ka taimerí pirms skailtiem, kas ir mazaki par 10 un lielaki par 0 ieskaitot tiek pielikta velviena 0
    	if(timer.seconds<10){
			textMesh.text = timer.minutes+":0"+timer.seconds;
    		//GameData.timeTxtMesh.text =timer.minutes+":0"+timer.seconds;
    	}
    	
    	else textMesh.text =timer.minutes+":"+timer.seconds;
		//izsaucam funkciju pec 1 sekundes un turpinam to izsaukt ik pec sekundes    
    	InvokeRepeating ("Countdown", 1.0f, 1.0f);
	}
	
	//f-ja, kas skaita minutes/sekundes un parada to uz attieciga objekta teksta komponentes
	void Countdown (){	
		//ja sekundes sasniedz 0 un minutes sasniedz 0, tad izsaucam f-ju
	    if (--timer.seconds==0 && timer.minutes==0){
	    	CancelTimer();
	    }
	    else if(timer.seconds<0){
	    	timer.seconds=59;
	    	timer.minutes--;
	    }
	    else if(timer.seconds<10){ 
	    	textMesh.text =timer.minutes+":0"+timer.seconds;
	    }
	    else textMesh.text =timer.minutes+":"+timer.seconds;
	}
	//f-ja kas teik izsaukta, tad kad beidzas noraditais laiks
	void CancelTimer(){
	    //Apstadina funkcijas CountDown izsauksanu ik pec sekundes
		CancelInvoke ("Countdown");
		//Ieladejam 3. ainu
		Application.LoadLevel(3);
	    //textMesh.gameObject.active=false;
	    //this.enabled=false;
	}
}
