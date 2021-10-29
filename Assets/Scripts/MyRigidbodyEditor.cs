using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyRigidbody))]
public class MyRigidbodyEditor : Editor
{

	MyRigidbody _target;

	private void OnEnable()
	{
		_target = (MyRigidbody)target;
	}


	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if(GUILayout.Button("Launch!"))
		{
			_target.Launch();
		}
		if(GUILayout.Button("Reset"))
		{
			_target.Stop();
		}
		if(GUILayout.Button("Duran Duran"))
		{
			_target.Reflect();
		}
	}
}
