using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupObj : MonoBehaviour {

    public Transform hand;
    Rigidbody rb;
    public Item myItem;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }


    public void Pickup()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.position = hand.position;
        transform.rotation = hand.rotation;
        transform.parent = hand;
    }

    public void Drop()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.parent = null;
    }

}
