using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private Vector3 defaultOffset;

    [SerializeField]
    private Vector3 currentCameraState;

    [SerializeField]
    private Player player;

    [SerializeField]
    private float cameraSensitivity;

	// Use this for initialization
	void Start () {
        defaultOffset = transform.position - player.transform.position;
        currentCameraState = player.transform.position + defaultOffset;

    }
	
	// Update is called once per frame
	void Update () {
        currentCameraState = Vector3.Lerp(currentCameraState, player.transform.position + defaultOffset, cameraSensitivity);
        transform.position = currentCameraState;
	}
}
