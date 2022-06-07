using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Original Author - Jack Dekko

public class ItemObjectPickup : MonoBehaviour
{

    private bool detectedPickup = false;
    private bool pickupItem = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detectedPickup is true) {
                Debug.Log("Pickup Item");
                pickupItem = true;
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {        
        //Check for a item match that collides with player
        if (collider.gameObject.tag == "Item")
        {
            //If item is detected, pickup is true otherwise false
            Debug.Log("Item Collision");
            detectedPickup = true;
        }

    }

    void OnTriggerStay2D(Collider2D collider) 
    {
        if (pickupItem is true) {
                collider.transform.parent = transform;
            }
        pickupItem = false;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        detectedPickup = false;
    }
}
