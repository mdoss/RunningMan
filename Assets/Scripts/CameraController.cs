using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform target;
    private float rotationSpeed = 5f;
    private float minY = -60f;
    private float maxY = 60f;
    private float rotationY = -30f;
    private float rotationX = 0f;
    private Vector3 offset;
     
    void Start() {
        offset = target.transform.position - transform.position;
    }
     
    void LateUpdate() {
        /*   float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
           target.transform.Rotate(0, horizontal, 0);


           float desiredAngle = target.transform.eulerAngles.y;
           Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
           transform.position = target.transform.position - (rotation * offset);

           transform.LookAt(target.transform);*/
        /* Camera follows the target */
        //transform.LookAt(target, Vector3.up);
        transform.position = target.position + offset;

        /* Camera rotation */
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
    }
}