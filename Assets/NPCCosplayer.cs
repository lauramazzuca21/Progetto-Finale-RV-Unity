using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCosplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _cosplayer;
    [SerializeField]
    private GameObject _charachterMesh;
    void Awake()
    {
        _cosplayer.SetActive(false);
        _charachterMesh.SetActive(false);
        GetComponent<Animator>().enabled = false;

        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(.5f);
        GetComponent<Animator>().enabled = true;
        _charachterMesh.SetActive(true);
        StopAllCoroutines();
    }

}
