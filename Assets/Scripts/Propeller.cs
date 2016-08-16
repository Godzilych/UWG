using UnityEngine;
using System.Collections;

public class Propeller : MonoBehaviour
{
    private SubmarineController sub;
	// Use this for initialization
	void Start ()
    {
        sub = transform.parent.gameObject.GetComponent<SubmarineController>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
