using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    GameObject Submarine;
    float cameraPivotStep = 3;
    private Rigidbody rb;

	// Use this for initialization
	void Start ()
    {
        Application.targetFrameRate = 60;
        Submarine = GameObject.Find("Submarine");
        rb = Submarine.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float targetY = rb.position.y + rb.velocity.normalized.y * cameraPivotStep;
        float targetX = rb.position.x + rb.velocity.normalized.x * cameraPivotStep;
        float deltaX = Mathf.Lerp(0, targetX-transform.position.x, Time.deltaTime);
        float deltaY = Mathf.Lerp(0, targetY - transform.position.y, Time.deltaTime);

        transform.Translate(deltaX, deltaY, 0);
	}
}
