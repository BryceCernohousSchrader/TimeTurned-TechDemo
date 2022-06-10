using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Original Author - Jack Dekko

/// <summary>
/// Player behavior that allows for "picking up" an item object
/// Pre Conditions: ~~~~~ (if applicable)
/// Post Conditions: ~~~~~ (if applicable)
/// </summary>
public class ItemObjectPickup : MonoBehaviour
{

    private bool pickupItem = false;

    // Might be helpful to know which objects on scene are detected as pickups
    [SerializeField] private bool detectedPickup = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && detectedPickup is true) {
                Debug.Log("Item object made child to Player.");
                pickupItem = true;
            }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {        
        //Check for a item match that collides with player
        if (collider.gameObject.tag == "Item")
        {
            //If item is detected, pickup is true otherwise false
            Debug.Log("Item Trigger.");
            detectedPickup = true;
        }

    }

    void OnTriggerStay2D(Collider2D collider) 
    {
        // Make Item object a child of the player in the hierarchy.
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
