using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageModel : MonoBehaviour {

    [SerializeField]
    private DeathArea deathAreaPrefab;
    [SerializeField]
    private float timer;
    [SerializeField]
    private float spawnRate;
    [SerializeField]
    private float spawnTimeLength;

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer < spawnTimeLength)
        {
            if (Random.Range(0f,1f) < spawnRate)
            {
                DeathArea created = Instantiate(deathAreaPrefab);
                created.transform.position = new Vector3(Random.Range(-25f, 25f), 1, Random.Range(-25f, 25f));
            }
        }
    }

}
