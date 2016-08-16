using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour {

    float enginePower=5000;
    float maxSteerAngle = 30;
    float steerPower = 500;
    float rotationSpeed = 45; // angle per sec
    float dirRot;
    Transform steer;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        dirRot = transform.rotation.y;
        steer = transform.Find("vSteer");
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump"))
        {
            dirRot = dirRot + 180;
        }
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, dirRot, 0), Time.deltaTime * 180 / rotationSpeed));

        if (Input.GetAxis("Horizontal") != 0)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal") * enginePower, 0, 0);
            rb.AddForce(dir * Time.deltaTime);
            
            //Debug.Log(rb.velocity);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            Vector3 dir = new Vector3(0,Input.GetAxis("Vertical") * steerPower * rb.velocity.magnitude,0);
            rb.AddForce(dir * Time.deltaTime);
            steer.localRotation = Quaternion.Euler(0, 0, Input.GetAxis("Vertical") * maxSteerAngle);

            Debug.Log(dir);
        }

    }
}
