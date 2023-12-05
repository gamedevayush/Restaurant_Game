using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public FixedTouchField touchField;
    public bool enableMobileInputs = true;
    float YAxis,XAxis;
    [Range(0.5f,2.0f)]
    public float RotationSensitivity = 8.0f;
    public GameObject Player;
    public Transform target;
    private Transform oldTarget,newTarget;
    [Range(0.05f,2.0f)]
    public float distanceFromPlayer = 0.05f;
    
     public float RotationMin = -20.0f;
     public float RotationMax = 38.0f;

    public float smoothness  = 0.12f;

    Vector3 targetRotation,currentVel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (enableMobileInputs)
        {
            YAxis += touchField.TouchDist.x * RotationSensitivity;

            XAxis -= touchField.TouchDist.y * RotationSensitivity;
        }
        else
        {
            YAxis += Input.GetAxis("Mouse X") * RotationSensitivity;

            XAxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }

        XAxis = Mathf.Clamp(XAxis,RotationMin,RotationMax);

        targetRotation = Vector3.SmoothDamp(targetRotation,new Vector3(XAxis,YAxis),ref currentVel,smoothness);
        transform.eulerAngles = targetRotation;


      //  transform.position = target.position - transform.forward * distanceFromPlayer;
    }
     
    public void RagdollEnabled()
    {
        oldTarget = target;
        Transform hipBone = Player.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Hips);
        
        target = hipBone;
    }

    public void RagdollDisabled()
    {
        target = oldTarget;
        oldTarget = null;
        
    }
}
