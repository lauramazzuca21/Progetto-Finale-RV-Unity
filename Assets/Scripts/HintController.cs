using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintController : MonoBehaviour
{
    [SerializeField]
    private GameObject _hintLabel;


    // Start is called before the first frame update
    void Start()
    {
       //activate label for a certain amount of time   
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ShowHint()
    {
        _hintLabel.SetActive(true);
    }
}
