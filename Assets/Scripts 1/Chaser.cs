using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
	public float TurnSpeed = 30f;

	public float Speed = 30f;

	public float AOB, ATI , AUX, Tri;

	public MyRigidbody Target;

	public void FixedUpdate()
	{
		Vector3 currentPosition = transform.position;
		Vector3 targetPosition = Target.Position;
		Vector3 targetCourse = Target.Velocity.normalized;

		 AOB = Vector3.Angle(targetPosition - currentPosition, targetCourse);

		 ATI = Mathf.Rad2Deg * Mathf.Asin((Mathf.Sin(AOB * Mathf.Deg2Rad) * Target.Velocity.magnitude) / Speed);
		
		if (ATI >= 90f)
		{
			Debug.DrawRay(transform.position, transform.forward * 10f, Color.red);
			transform.position = Vector3.MoveTowards(transform.position, transform.forward * Speed, Time.fixedDeltaTime);
			Debug.Log("Interception not possible");
			return;
		}

		AUX = 180 - ATI - AOB;

		Tri = AOB + AUX + ATI;

		float timeUntilIntersection = Mathf.Abs(Mathf.Sin(AOB * Mathf.Deg2Rad) * Vector3.Distance(currentPosition, targetPosition)/ (AUX * Mathf.Deg2Rad) / Speed);

		Vector3 intersectPosition = targetPosition + Target.Velocity * timeUntilIntersection;

		transform.position = Vector3.MoveTowards(transform.position, intersectPosition, Time.fixedDeltaTime * Speed);

		Debug.DrawLine(currentPosition, intersectPosition);
		//Debug.Log(timeUntilIntersection);

	}
}
