using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public float cameraMoveSpeed = 120.0f;
    public GameObject cameraFollowObj;
    public float clampAngle = 80.0f;
    public float inputSensitivityMouse = 150.0f;
    public float inputSensitivityPhone = 8.0f;
    public FixedTouchField touchField;
    public Slider sensitivitySlider;

    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }
   public void SetTarget(GameObject givenTransform)
    {
        cameraFollowObj = givenTransform;
    }
    void Update()
    {
        // Handle input from mouse and touch
        float inputX = touchField.TouchDist.x * inputSensitivityPhone;
        float inputZ = touchField.TouchDist.y * inputSensitivityPhone;
        float mouseX = Input.GetAxis("Mouse X") * inputSensitivityMouse;
        float mouseY = Input.GetAxis("Mouse Y") * inputSensitivityMouse;

        rotY += (inputX + mouseX) * Time.deltaTime;
        rotX += (inputZ + mouseY) * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        if (cameraFollowObj != null)
        {
            float step = cameraMoveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cameraFollowObj.transform.position, step);
        }
    }

    public void ChangeSensitivity()
    {
        inputSensitivityPhone = sensitivitySlider.value;
    }
}
