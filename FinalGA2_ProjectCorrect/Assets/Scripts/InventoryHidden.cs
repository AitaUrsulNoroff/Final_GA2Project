using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHidden : MonoBehaviour
{
 
    public Image inventoryImage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var activeChildren = 0;
        foreach (Transform child in transform) 
        {
            if (child.gameObject.activeSelf)
            {
                inventoryImage.enabled = true;
                activeChildren++;

            }
        
        }
         if (activeChildren == 0) 
        {
            inventoryImage.enabled = false;
        }

    }
}
