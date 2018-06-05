using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private ParticleSystem deathEffectPrefab;

    void Move()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(inputX, 0, inputZ) * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        //死
        Instantiate(deathEffectPrefab, transform);
    }

    void Update()
    {
        Move();
    }
}
