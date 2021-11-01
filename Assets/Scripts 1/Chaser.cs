using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
	public float TurnSpeed = 30f;

	public float Speed = 30f;

	public MyRigidbody Target;

	public void FixedUpdate()
	{
		Vector3 currentPosition = transform.position;
		Vector3 targetPosition = Target.Position;
		Vector3 targetCourse = Target.Velocity.normalized;

		float AOB = Vector3.Angle(targetPosition - currentPosition, targetCourse);

		float ATI = Mathf.Asin((Mathf.Sin(AOB) * Target.Velocity.magnitude) / Speed);

		float timeUntilIntersection = Mathf.Abs(Mathf.Sin(AOB) * Vector3.Distance(currentPosition, targetPosition)/ (Mathf.Sin(180 - ATI - AOB) / Speed));

		Vector3 intersectPosition = targetPosition + Target.Velocity.normalized * timeUntilIntersection;

		transform.position = Vector3.MoveTowards(transform.position, intersectPosition, Time.fixedDeltaTime * Speed);

		Debug.DrawLine(currentPosition, intersectPosition);
		Debug.Log(timeUntilIntersection);

	}
}
