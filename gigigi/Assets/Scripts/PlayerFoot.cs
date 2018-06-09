using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//足元 設置判定用
public class PlayerFoot : MonoBehaviour {

    [SerializeField]
    private FloorPanel currentGround;

    [SerializeField]
    public bool isGrounded {
        get {
            if (!currentGround)
            {
                return false;
            }
            return currentGround.transform.position.y > -0.5f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Floor")
        {
            return;
        }
        currentGround = other.gameObject.GetComponent<FloorPanel>();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag != "Floor")
        {
            return;
        }
        currentGround = other.gameObject.GetComponent<FloorPanel>();
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Floor")
        {
            return;
        }
        currentGround = null;
    }

}
