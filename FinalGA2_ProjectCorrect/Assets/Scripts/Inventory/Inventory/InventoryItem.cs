using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  //Need this to get at GUI elements

[RequireComponent(typeof(SphereCollider))]

public class InventoryItem : MonoBehaviour
{
    public float pickupRange = 1.5f;
    public Image InvItem2d;     //image in inventory for this object
    bool isInTrigger = false;   //is player in trigger volume at the moment?
    public bool isForBackpack, isForCharger, isForGrowthTank;  //Capital means space between words.
    public BackPackFilling backpackFilling;
    public BatteryChargerFilling batteryChargerFilling;
    public AlgaeGrowthFiller algaeGrowthFiller;
    private SphereCollider sphereCollider;
    public TMP_Text text;


    private void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();

        sphereCollider.isTrigger = true;

        sphereCollider.radius = pickupRange;
    }

    // Update is called once per frame
    void Update()
    {
        //E key press AND player in volume
        if( Input.GetKeyDown(KeyCode.E) && isInTrigger)
        {
            //hide 3d object
            transform.gameObject.SetActive(false);

            if (isForBackpack) 
            {
                
                
                backpackFilling.backpackItems.Add(InvItem2d);
            }

            if (isForCharger) 
            { 
                batteryChargerFilling.hasCollectedBattery = true; 
            }

            if (isForGrowthTank) 
            {
                algaeGrowthFiller.hasCollectedAlgaeVial = true;
            }

            //show the icon in the invemtory bar
            InvItem2d.gameObject.SetActive(true);

            if (!text) return;

            QuestLog.FormatString(text);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        //so update can handle the trigger with a key press :(
        if(other.tag == "Player")
        {
            isInTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //not in trigger
        if (other.tag == "Player")
        {
            isInTrigger = false;

        }
    }
}
