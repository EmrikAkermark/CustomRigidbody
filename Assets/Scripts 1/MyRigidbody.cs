using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidbody : MonoBehaviour
{
	[Min(0.1f)]
	public float Mass = 0.1f;

	public float Gravity = 9.82f, PropulsionTime = 1f, ArbitraryDrag = 10f;
	public Vector3 Force, Acceleration, Velocity, Position, Normal;

	private float timer;
	private bool doSimulation = false;

	public void Launch()
	{
		doSimulation = true;
		ResetPosition();
	}

	public void Stop()
	{
		doSimulation = false;
		ResetPosition();
	}

	public void Reflect()
	{

		Normal = Normal.normalized;

		float dot = Vector3.Dot(Velocity, Normal);

		if(dot < 0)
		{
			Normal = -Normal;
		}

		Velocity = Velocity - 2 * Vector3.Dot(Velocity, Normal) * Normal;
	}


	private void ResetPosition()
	{

		Acceleration = Vector3.zero;
		Velocity = Vector3.zero;
		Position = Vector3.zero;
		transform.position = Position;
		timer = 0f;
	}

	public void FixedUpdate()
	{
		if(doSimulation == false)
		{
			return;
		}

		if(timer <= PropulsionTime)
		{
			Acceleration = Force / Mass + Vector3.down * Gravity;
			timer += Time.fixedDeltaTime;
		}
		else
		{
			Acceleration = Vector3.down * Gravity;
		}


		Velocity += Acceleration * Time.fixedDeltaTime;

		Velocity -= Velocity * Velocity.magnitude * ArbitraryDrag * 0.5f * Time.fixedDeltaTime;

		Position += Velocity * Time.fixedDeltaTime;

		transform.position = Position;

	}
}
