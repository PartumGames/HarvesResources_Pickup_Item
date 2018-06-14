using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Camera cam;
    public Transform hand;
    public float interactDist = 10f;

    public GameObject objImHolding;
    public Item myItem;
    public bool isholding;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Drop();
        }

        DoInteraction();
    }

    private void DoInteraction()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, interactDist))
        {
            if(hit.collider.tag == "Harvest")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Harvest currentHarvest = hit.collider.GetComponent<Harvest>();
                    currentHarvest.HarvestResources(myItem.itemAttackDamage);
                }
            }


            if(hit.collider.tag == "Pickup")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PickupObject(hit.collider.gameObject);
                }
            }

            
        }
    }

    private void PickupObject(GameObject objToPickup)
    {
        if (isholding)
        {
            Drop();
        }

        objImHolding = objToPickup;
        objImHolding.GetComponent<PickupObj>().Pickup();
        myItem = objImHolding.GetComponent<PickupObj>().myItem;
        isholding = true;
    }

    private void Drop()
    {
        objImHolding.GetComponent<PickupObj>().Drop();
        objImHolding = null;
        myItem = null;
        isholding = false;
    }


    //private void Attack(TestDummy go)
    //{
    //    if (itemImHolding != null)
    //    {
    //        go.TakeDamage(myItem.itemAttackDamage);
    //    }
    //    else
    //    {
    //        print("You need a weapon to attack");
    //    }
    //}
}
