using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	// PLAYER SPEED & MOVEMENT VARIABLES
	public float speed										= 12.0f;
	public float reverseSpeed								= 5.0f;
	public float turnSpeed									= 0.2f;
			
	private float moveDirection								= 0.0f;
	private float turnDirection								= 0.0f;
	
	public float currentSpeed								= 0.0f;

	public bool isMoving									= false;

	// PLAYER FIRE EFFECTS
	public ParticleSystem BackThruster;
	public ParticleSystem LeftThruster;
	public ParticleSystem RightThruster;
	public ParticleEmitter ThrusterEffect;
	public float effectTimer = 0.3f;
	private float resetEffectTimer;
	public AudioClip thrusterAudio;

	// Use this for initialization
	void Start () 
	{
		ThrusterEffect.particleEmitter.emit			= false;
		BackThruster.enableEmission 				= false;
		LeftThruster.enableEmission 				= false;
		RightThruster.enableEmission 				= false;
		resetEffectTimer = effectTimer;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//DRAG AND ANGULAR DRAG VARIABLES
		currentSpeed = Mathf.Abs(transform.InverseTransformDirection(rigidbody.velocity).z);
		
		float maxAngularDrag 								= 2.5f;
		float currentangularDrag 							= 1.0f;
		float aDragLerpTime									= currentSpeed * 0.1f;
		
		float maxDrag 										= 1.0f;
		float currentDrag 									= 2.5f;
		float dragLerpTime									= currentSpeed * 0.1f;
		
		float myAngularDrag = Mathf.Lerp(currentangularDrag, maxAngularDrag, aDragLerpTime);
		float myDrag = Mathf.Lerp(currentDrag, maxDrag, dragLerpTime);
		
		//ACCELERATION MOVEMENT
		if(Input.GetKey("w"))
		{
			effectTimer -= Time.deltaTime;
			moveDirection = Input.GetAxis("Vertical") * speed;
			rigidbody.AddRelativeForce(0, 0, moveDirection);

			BackThruster.enableEmission = true;
			if (effectTimer < 0.0f)
			{
				ThrusterEffect.particleEmitter.emit			= true;
			}


			isMoving = true;
		}
		
		//REVERSE MOVEMENT
		else if(Input.GetKey("s"))
		{
			moveDirection = Input.GetAxis("Vertical") * speed;
			rigidbody.AddRelativeForce(0, 0, moveDirection);

			LeftThruster.enableEmission = true;
			RightThruster.enableEmission = true;

			isMoving = true;
		}
		
		else 
		{
			ThrusterEffect.particleEmitter.emit		= false;
			BackThruster.enableEmission = false;
			LeftThruster.enableEmission = false;
			RightThruster.enableEmission = false;
			effectTimer = resetEffectTimer;
			isMoving = false;
		}
		//TURN MOVEMENT
		if(Input.GetAxis("Horizontal") > 0.0f)
		{
			turnDirection = Input.GetAxis("Horizontal") * turnSpeed;
			rigidbody.AddRelativeTorque(0, turnDirection, 0);
			
			LeftThruster.enableEmission = true;
			RightThruster.enableEmission = false;
			isMoving = true;
		}
		
		else if(Input.GetAxis("Horizontal") < 0.0f)
		{
			turnDirection = Input.GetAxis("Horizontal") * turnSpeed;
			rigidbody.AddRelativeTorque(0, turnDirection, 0);
			
			LeftThruster.enableEmission = false;
			RightThruster.enableEmission = true;
			isMoving = true;
		}
		else
		{
			if (!Input.GetKey("s"))
			{
				LeftThruster.enableEmission = false;
				RightThruster.enableEmission = false;
			}
		}

		if (isMoving)
		{
			audio.enabled = true;
		}
		else 
		{
			audio.enabled = false;
		}
	}
}















