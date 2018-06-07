using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPanel : MonoBehaviour {

    [SerializeField]
    private bool isFalling;

    [SerializeField]
    private float velocity;
    [SerializeField]
    private float fallSpeedRate;

    public void StartFall()
    {
        isFalling = true;
    }

    private void Fall()
    {
        velocity += fallSpeedRate;
        transform.Translate(new Vector3(0, -velocity, 0));
    }

	// Use this for initialization
	void Start () {
        isFalling = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isFalling)
        {
            Fall();
        }
	}
}
