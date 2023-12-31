﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour {

	public float CameraMoveSpeed = 120.0f;
	public GameObject CameraFollowObj;
	Vector3 FollowPOS;
	public float clampAngle = 80.0f;
	public float inputSensitivityMouse = 150.0f;
	public float inputSensitivityPhone = 8.0f;
	public GameObject CameraObj;
	public GameObject PlayerObj;
	public float camDistanceXToPlayer;
	public float camDistanceYToPlayer;
	public float camDistanceZToPlayer;
	public float mouseX;
	public float mouseY;
	public float finalInputX;
	public float finalInputZ;
	public float smoothX;
	public float smoothY;
	private float rotY = 0.0f;
	private float rotX = 0.0f;
	public Transform target;
	public FixedTouchField touchField;
	public Slider senstivitySlider;



	// Use this for initialization
	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotY = rot.y;
		rotX = rot.x;
		
	}
	
	// Update is called once per frame
	void Update () {

		// We setup the rotation of the sticks here
		float inputX = touchField.TouchDist.x * inputSensitivityPhone;
		float inputZ = touchField.TouchDist.y * inputSensitivityPhone;
		mouseX = Input.GetAxis ("Mouse X") * inputSensitivityMouse;
		mouseY = Input.GetAxis ("Mouse Y") * inputSensitivityMouse;
		finalInputX = inputX + mouseX;
		finalInputZ = inputZ + mouseY;

		rotY += finalInputX * Time.deltaTime;
		rotX += finalInputZ  * Time.deltaTime;

		rotX = Mathf.Clamp (rotX, -clampAngle, clampAngle);

		Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
		transform.rotation = localRotation;


	}

	void LateUpdate () {
		CameraUpdater ();
	}

	void CameraUpdater() {
		// set the target object to follow
		target = CameraFollowObj.transform;

		//move towards the game object that is the target
		float step = CameraMoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
	}

	public void changeSensitivity()
	{
		inputSensitivityPhone = senstivitySlider.value;
	}
}
