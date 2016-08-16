using UnityEngine;
using System.Collections;

// this class controlls object bouyancy
public class Bouyancy : MonoBehaviour
{
    public float depth;
    public float pressureMod;
    public float bouyacyForce;
    public float objVolume;
    public float objAirVolume;
    public Rigidbody rb;


	// Use this for initialization
	void Start ()
    {
        rb = this.GetComponent<Rigidbody>();
        GetDepth(this.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        AddBouyancyForce();
	}

    float GetDepth (GameObject obj)
    {
        depth = Mathf.Abs(Mathf.Min( obj.transform.position.y, 0));

        //Debug.Log("depth:" + depth);

        return depth;
    }

    void AddBouyancyForce ()
    {
        float currentVolume = (objVolume + objAirVolume / (1 + depth / pressureMod)) * Mathf.Min(GetDepth(this.gameObject), 1);

        bouyacyForce = currentVolume * 9.8f;
        rb.AddForce(Vector3.up * bouyacyForce * Time.deltaTime);
        //Debug.Log("force:" + bouyacyForce);
    }
}
