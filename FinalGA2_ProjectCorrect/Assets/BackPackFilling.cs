using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackFilling : MonoBehaviour
{
    bool isInTrigger;
    [SerializeField] List<MeshRenderer> meshRenderers;
    [SerializeField] List<Animation> animators;
    [SerializeField] GameObject[] itemList;
    private BoxCollider boxCollider;
    [SerializeField] float delay = 1;

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

        isInTrigger = false;

        boxCollider.enabled = false;

        StartCoroutine(StartAnimatonDelay());
    }
    IEnumerator StartAnimatonDelay()
    {
        for (int i = 0; i < animators.Count; i++)
        {
            meshRenderers[i].enabled = true;

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
