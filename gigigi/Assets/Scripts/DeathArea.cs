using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathArea : MonoBehaviour {
    [SerializeField ]
    private GameObject cautionArea;
    [SerializeField]
    private GameObject deathArea;
    [SerializeField]
    private float cautionFillTime;
    [SerializeField]
    private float deathFillTime;
    [SerializeField]
    private float linguarTime;
    [SerializeField]
    private float decayTime;
    [SerializeField]
    private float timer;

    public enum State
    {
        CAUTION,
        DEATH,
        LINGUAR,
        DECAY,
    }

    [SerializeField]
    private State state;

    public void fixCautionAreaScale()
    {
        cautionArea.transform.localScale = new Vector3(1, 1, 1);
    }
    public void fixDeathAreaScale()
    {
        deathArea.transform.localScale = new Vector3(1, 1, 1);
    }

    // Use this for initialization
    void Start () {
        timer = 0f;
        deathArea.transform.localScale = Vector3.zero;
        cautionArea.transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        switch (state)
        {
            case State.CAUTION:
                cautionArea.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(1, 1, 1),  Mathf.Pow(timer / cautionFillTime,3));
                if (timer >= cautionFillTime)
                {
                    timer = 0f;
                    state = State.DEATH;
                }
                break;
            case State.DEATH:
                deathArea.transform.localScale = Vector3.Lerp(Vector3.zero, new Vector3(1, 1, 1), Mathf.Pow(timer / deathFillTime, 5));
                if (timer >= deathFillTime)
                {
                    timer = 0f;
                    state = State.LINGUAR;
                }
                break;
            case State.LINGUAR:
                if (timer >= linguarTime)
                {
                    timer = 0f;
                    state = State.DECAY;
                    cautionArea.gameObject.SetActive(false);
                }
                break;
            case State.DECAY:
                deathArea.transform.localScale = Vector3.Lerp(new Vector3(1, 1, 1), Vector3.zero, Mathf.Pow(timer / decayTime, 3));
                if (timer >= decayTime)
                {
                    Destroy(gameObject);
                }
                break;
        }
    }
}
