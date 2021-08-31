using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotoCotroller : MonoBehaviour {

	private float speed;
	public WheelJoint2D backwheel;


	private float movement = 0;

	void Update()
	{
		
	}
	void FixedUpdate()
	{
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            speed = 500f;
        }
        else speed = 700f;



		movement = Input.GetAxisRaw ("Vertical")*speed;

		if (movement == 0) {
			backwheel.useMotor = false;
		} else
		{
			backwheel.useMotor = true;
			JointMotor2D ourMotor = new JointMotor2D{ motorSpeed = -movement, maxMotorTorque = 10000 };
			backwheel.motor = ourMotor;
			
		}




	}

}
