using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabFridgeDoorController : MonoBehaviour
{

    Animator LabFridgeDoor;
    bool isInTrigger = false;
    bool isOpen = false;
    public InventoryItem vial;
    public void OnTriggerEnter (Collider other) 
    

    {
        if (other.CompareTag("Player"))
            isInTrigger = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           isInTrigger = false;
        }

    }
    IEnumerator DelayCanPickup()  
    {
        yield return new WaitForEndOfFrame();

        vial.canPickup = !vial.canPickup;
    
    }

    // Start is called before the first frame update
    void Start()
    {
        LabFridgeDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && isInTrigger && !isOpen)
        {
            if (LabFridgeDoor)
            {
                Debug.Log("door open");
                LabFridgeDoor.SetTrigger("openDoor");
                isOpen = true;

                StartCoroutine(DelayCanPickup());

                //vial.canPickup = true;
            }
            else
            {
                Debug.Log("no door!");

            }

            
        } 
        
        if (Input.GetKeyDown(KeyCode.R) && isInTrigger && isOpen)
        {
            if (LabFridgeDoor)
            {
                Debug.Log("door close");
                LabFridgeDoor.SetTrigger("closeDoor");
                isOpen = false;

                StartCoroutine(DelayCanPickup());

                //vial.canPickup = false;
            }
            else
            {
                Debug.Log("no door!");
            }
        }
        
    }
}
