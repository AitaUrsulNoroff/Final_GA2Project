using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class BatteryChargerFilling : MonoBehaviour
{
    [SerializeField] Animation mAnimation;

    public bool hasCollectedBattery;
    public Image battery2DImage;
    private BoxCollider boxCollider;
    private bool isInTrigger;
    public TMP_Text text;
    


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        isInTrigger = true;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        isInTrigger = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInTrigger) return;

        if (!Input.GetKeyDown(KeyCode.E)) return;

        if (!hasCollectedBattery) return;

        QuestLog.FormatString(text);

        hasCollectedBattery = false;

        battery2DImage.gameObject.SetActive (false);

        mAnimation.Play();

        boxCollider.enabled = false;
    }
}
