using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour {

    float enginePower=5000;
    float maxSteerAngle;
    float rotationSpeed = 45; // angle per sec
    float dirRot;
    Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        dirRot = transform.rotation.y;

	
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        if(Input.GetButtonDown("Jump"))
        {
            dirRot = dirRot + 180;
            //StopCoroutine("RotateCorutine");
            //StartCoroutine(RotateCorutine(dirRot));
        }
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, dirRot, 0), Time.deltaTime * 180 / rotationSpeed));

        if (Input.GetAxis("Horizontal") !=0)
        {
            Vector3 dir = new Vector3(Input.GetAxis("Horizontal") * enginePower,0,0);
            rb.AddForce(dir * Time.deltaTime);
            Debug.Log(rb.velocity);
        }
    }
    /*
    IEnumerator RotateCorutine( float target)
    {
        Quaternion tAngle;
        Debug.Log("pos:" + transform.rotation.y +"target:" + target);
        while(transform.rotation.y != target)
        {
            tAngle = Quaternion.Euler(0, target,0);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, tAngle, Time.deltaTime * rotationSpeed ));

            Debug.Log(tAngle);

            yield return null;
        }
    }
    */

    void Rotation()
    {
        float t = 0;
        while (t < rotationSpeed)
            {

            }
    }
}
