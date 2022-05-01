using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCosplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject _cosplayer;
    //[SerializeField]
    //private ParticleSystem _changeEffect;
    // Start is called before the first frame update
    void Awake()
    {
        //_changeEffect.Play();
        _cosplayer.SetActive(false);
    }
}
