using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationScript : MonoBehaviour {
    public Rigidbody myRigidbody;

    public Camera mainCam;

    public GameObject pauseMenu;


    public float XSensitivity = 5.0f;
    public float YSensitivity = 5.0f;
    public float RotX;
    public float RotY;
    public bool canDrag;
    public bool dragging;


    void ApplyForce(Rigidbody camCenter)
    {
        Vector3 direction = camCenter.transform.position - transform.position;
        camCenter.AddForceAtPosition(direction.normalized, transform.position);
    }

    void ApplyForce1(Rigidbody myRigidbody)
    {
        Vector3 direction = myRigidbody.transform.position - transform.position;
        myRigidbody.AddForceAtPosition(direction.normalized, transform.position);
    }

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");


        if (pauseMenu.GetComponent<PauseScript>().isPaused == false)
        {

            mainCam.transform.LookAt(gameObject.transform);

            if (Input.GetMouseButtonDown(0) && canDrag == true)
            {
                dragging = true;

            }
            if (Input.GetMouseButtonUp(0) && canDrag == true)
            {
                dragging = false;
            }

            if (dragging == true)
            {
                RotX = Input.GetAxis("Mouse X") * XSensitivity;
                this.gameObject.transform.Rotate(0, RotX, 0);

                RotY = Input.GetAxis("Mouse Y") * YSensitivity;

            }
        }
    }

    public void ActivateCameraRotation()
    {
        canDrag = true;
    }

    public void DeactivateCameraRotation()
    {
        canDrag = false;
        dragging = false;
    }
}
