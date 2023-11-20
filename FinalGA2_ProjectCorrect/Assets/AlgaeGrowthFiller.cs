using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.UI;

public class AlgaeGrowthFiller : MonoBehaviour
{
    [SerializeField] Animation mAnimation;

    public bool hasCollectedAlgaeVial;
    public Image algaeVial2DImage;
    private BoxCollider boxCollider;
    private bool isInTrigger;
    public TMP_Text text, questComplete;


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

        if (!hasCollectedAlgaeVial) return;

        QuestLog.FormatString(text);
        QuestLog.FormatString(questComplete);

        hasCollectedAlgaeVial = false;

        algaeVial2DImage.gameObject.SetActive (false);

        mAnimation.Play();

        boxCollider.enabled = false;
    }
}
