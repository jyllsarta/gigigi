using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//足元 設置判定用
public class PlayerFoot : MonoBehaviour {

    [SerializeField]
    public bool isGrounded { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Floor")
        {
            return;
        }
        Debug.Log("T");
        isGrounded = true;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Floor")
        {
            return;
        }
        Debug.Log("T");
        isGrounded = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Floor")
        {
            return;
        }
        Debug.Log("F");
        isGrounded = false;
    }

    void Start()
    {
        isGrounded = true;
    }

}
