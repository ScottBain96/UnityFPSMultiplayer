using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>(); 
    }

    private void Update()
    {
        //calculate movement velocity as a 3D vector
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov; 
        Vector3 movVertical = transform.forward * zMov;

        //final movement vector
        Vector3 _velocity = (movHorizontal + movVertical).normalized * speed;

        //Apply movement

        motor.Move(_velocity);


        //calculate rotation as a 3D vector

        float yRota = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, yRota, 0f) * lookSensitivity;

        //Apply Rotation

        motor.Rotate(_rotation);






        //calculate Camera Rotation as a 3D vector

        float xRota = Input.GetAxisRaw("Mouse Y");

        Vector3 _cameraRotation = new Vector3(xRota, 0f, 0f) * lookSensitivity;

        //Apply Rotation

        motor.RotateCamera(_cameraRotation);




    }

}
