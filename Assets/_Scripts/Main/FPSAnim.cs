using UnityEngine;
using System.Collections;

[System.Serializable]
public class MovementSpeed{
	/*
	 * Klases merkis ir glabat klases objekta instancee kustibas atrumu dazados virzienos un rezimos
	 */
	public float maxForwardSpeed;
	public float maxSidewaysSpeed;
	public float maxBackwardsSpeed;
	
	//konstruktors
	public MovementSpeed(float p1,float p2,float p3){
		maxForwardSpeed = p1;
		maxSidewaysSpeed = p2;
		maxBackwardsSpeed = p3;
	}
}

public class FPSAnim : MonoBehaviour {
	/*
	 * klases merkis ir veikt speletaja iesanas/skriesanas rezimu parslegsanos un ieroca animacijas kontroli
	 * atkariba no rezima
	 */
	
	public MovementSpeed walkSpeed = new MovementSpeed(3.0f,4.0f,2.0f);
	public MovementSpeed runSpeed = new MovementSpeed(6.0f,4.0f,3.0f);
	
	public GameObject currentWeapon;
	public AnimationClip rifleSprint;
	public AnimationClip rifleBob;
	GameObject laser;

	CharacterMotor motor;
	
	//MonoBehaviour f-ja, kas tiek izsaukta katru reizi, kad tiek izpildíts viens kadrs
	void Update () {
		
		//iegustam speletaja kontroles kustibu horizontala virziena
		float horizontal = Input.GetAxis("Horizontal"); 
		//iegustam speletaja kontroles kustibu vertikala virziena
		float vertical = Input.GetAxis("Vertical"); 
		
		//ja kustiba notiek pa pozitivu vai negativu asi un NAV nospiesta Sprint poga
		if((horizontal!=0 || vertical!=0) &&!Input.GetButton("Sprint")){
			//noradam iesanas kustibas atrumu 
			SetMovement(walkSpeed);
			//palaisam animaciju plustosi parejot no ieprieksejas animacijas
			currentWeapon.animation.CrossFade("RifleBob");
			//aktivizejam lazera objektu
			laser.active=true;
			//noradam, ka var saut
			GameData.canShoot = true;
		}
		//ja kustiba notiek pa pozitivu vai negativu asi un IR nospiesta Sprint poga
		else if((horizontal!=0 || vertical!=0) &&Input.GetButton("Sprint")){
			//noradam skriesanas kustibas atrumu 
			SetMovement(runSpeed);
			//palaisam animaciju plustosi parejot no ieprieksejas animacijas
			currentWeapon.animation.CrossFade("RifleSprint");
			//deaktivizejam lazera objektu
			laser.active=false;
			//noradam, ka nevar saut
			GameData.canShoot = false;
		}
		else{
			//noradam iesanas kustibas atrumu 
			SetMovement(walkSpeed);
			//apstadinat animaciju un to attinam uz animacijas sakumu
			currentWeapon.animation.Stop();
			//aktivizejam lazera objektu
			laser.active=true;
			//noradam, ka var saut
			GameData.canShoot = true;
		}
		
	}
	//MonoBehaviour f-ja, kas tiek izpildita ainai uzsakoties
	void Start () {
		//iegustam lazera objektu, meklejot to pasreizeja objekta hierarhijaa pec varda
		laser = currentWeapon.transform.Find("laser").gameObject;
		//iegustam charMotor, kas atbild par speletaja kustibam (leksanu, kustibu, atrumu, utml.) runtaimá (iebuveets resurss)
		
		motor = GetComponent<CharacterMotor>();
		//noradam iesanas kustibas atrumu 
		SetMovement(walkSpeed);
	}
	//f-ja, kas CharMotora kustibas atrumu nomaina ar padoto MovementSpeed tipa objekta atributiem
	void SetMovement(MovementSpeed ms){
		motor.movement.maxForwardSpeed = ms.maxForwardSpeed;
		motor.movement.maxSidewaysSpeed = ms.maxSidewaysSpeed;
		motor.movement.maxBackwardsSpeed = ms.maxBackwardsSpeed;
	}
	
}
