using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCosplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _cosplayer;
    // Start is called before the first frame update
    void Awake()
    {
        _cosplayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
