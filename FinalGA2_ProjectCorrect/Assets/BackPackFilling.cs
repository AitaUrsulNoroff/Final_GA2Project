using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackPackFilling : MonoBehaviour
{
    bool isInTrigger;
    [SerializeField] List<MeshRenderer> meshRenderers;
    [SerializeField] List<Animation> animators;
    [SerializeField] GameObject[] itemList;
    private BoxCollider boxCollider;
    [SerializeField] float delay = 1;
    public int numberOfRequiredItems = 5;
    public List<Image> backpackItems = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!isInTrigger) return;

        //TODO condition for items. Sånn at du må ha items for å kunne trykke E.

        if (!Input.GetKeyDown(KeyCode.E)) return;

        if (backpackItems.Count == numberOfRequiredItems) 
        {
            isInTrigger = false;

            boxCollider.enabled = false;

            StartCoroutine(StartAnimatonDelay());


        }

        
    }
    IEnumerator StartAnimatonDelay()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            meshRenderers[i].enabled = true;

            backpackItems[i].gameObject.SetActive (false);

            animators[i].Play();
            yield return new WaitForSeconds(delay);
        }


    }

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
}
