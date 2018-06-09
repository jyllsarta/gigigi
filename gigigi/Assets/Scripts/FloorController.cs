using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    [SerializeField]
    private List<FloorPanel> floorPanels;

    [SerializeField]
    private float fallPanelInterval;

    [SerializeField]
    private float timer;


	// Use this for initialization
	void Start () {
        floorPanels = new List<FloorPanel>(GetComponentsInChildren<FloorPanel>());
        timer = 0f;
	}
	
    void FixedUpdate () {
        timer += Time.deltaTime;
        if (timer >= fallPanelInterval)
        {
            timer = 0f;
            floorPanels[Random.Range(0, floorPanels.Count)].StartFall();
        }
    }
}
