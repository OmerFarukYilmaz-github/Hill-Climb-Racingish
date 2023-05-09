using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	[SerializeField] float speed = 1500f;
	[SerializeField] float rotationSpeed = 15f;

	[SerializeField] WheelJoint2D backWheel;
	[SerializeField] WheelJoint2D frontWheel;

	[SerializeField] Rigidbody2D rb;

	private float movement = 0f;
	private float rotation = 0f;

	void Update ()
	{
		movement = -Input.GetAxisRaw("Vertical") * speed;
		rotation = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate ()
	{
		if (movement == 0f)
		{
			backWheel.useMotor = false;
			frontWheel.useMotor = false;
		} else
		{
			backWheel.useMotor = true;
			frontWheel.useMotor = true;

			JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = 10000 };
			backWheel.motor = motor;
			frontWheel.motor = motor;
		}

		rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);
    }

}
