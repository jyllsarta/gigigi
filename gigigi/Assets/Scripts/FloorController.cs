using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour {

    [SerializeField]
    private List<FloorPanel> floorPanels;

    [SerializeField]
    private float fallPanelInterval;

    [SerializeField]
    private float initialInterval;

    [SerializeField]
    private float timer;

    [SerializeField]
    private State state;

    [SerializeField]
    private int fallingCount;

    public enum State
    {
        InitialWaiting,
        Falling,
    }


	// Use this for initialization
	void Start () {
        floorPanels = new List<FloorPanel>(GetComponentsInChildren<FloorPanel>());
        timer = 0f;
	}
	
	void FixedUpdate () {
        timer += Time.deltaTime;
        switch (state)
        {
            case State.InitialWaiting:
                if (timer > initialInterval)
                {
                    timer = 0f;
                    state = State.Falling;
                }
                break;
            case State.Falling:
                if (timer < fallPanelInterval)
                {
                    return;
                }

                timer = 0f;

                if (fallingCount >= floorPanels.Count)
                {
                    return;
                }
                floorPanels[fallingCount].StartFall();
                fallingCount++;
                break;

        }

	}
}
