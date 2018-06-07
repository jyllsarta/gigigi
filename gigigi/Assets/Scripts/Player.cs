using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private ParticleSystem deathEffectPrefab;

    //設置判定用
    [SerializeField]
    private PlayerFoot playerFoot;

    void Move()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(inputX, 0, inputZ) * speed;
    }

    void Fall()
    {
        Debug.Log(playerFoot.isGrounded);
        if (playerFoot.isGrounded)
        {
            return;
        }
        transform.Translate(0, -0.1f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        //死
        if (other.tag != "DeathArea")
        {
            return;
        }
        Instantiate(deathEffectPrefab, transform);
    }

    void Update()
    {
        Move();
        Fall();
    }
}
