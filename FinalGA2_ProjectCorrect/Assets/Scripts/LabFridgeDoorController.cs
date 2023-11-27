using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabFridgeDoorController : MonoBehaviour
{
    Animator LabFridgeDoor;

    // Start is called before the first frame update
    void Start()
    {
        LabFridgeDoor = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LabFridgeDoor)
            {
                Debug.Log("door open");
                LabFridgeDoor.SetTrigger("openDoor");
            }
            else
            {
                Debug.Log("no door!");

            }
        } 
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (LabFridgeDoor)
            {
                Debug.Log("door close");
                LabFridgeDoor.SetTrigger("closeDoor");

            }
            else
            {
                Debug.Log("no door!");
            }
        }
        
    }
}
