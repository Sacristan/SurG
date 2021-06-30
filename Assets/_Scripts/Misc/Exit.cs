using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	/*
	 * Klases merkis ir nokert gadijumu, ja spelets tiek no Standalone versijas un tiek piespiests Esc, tad iziet no speles
	 */
	
	void Update () {
		//parbauda vai ir Standalone versija
		if(Application.platform==RuntimePlatform.LinuxPlayer||Application.platform==RuntimePlatform.OSXPlayer
			||Application.platform==RuntimePlatform.WindowsPlayer){
			//ja tiek piespiests Escape
			if(Input.GetKeyDown(KeyCode.Escape)){
				//izejam no speles
				Application.Quit();
			}
		}
	}
}
