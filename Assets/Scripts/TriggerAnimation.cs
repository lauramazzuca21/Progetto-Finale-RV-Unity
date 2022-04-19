using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    //ref to animator
    [SerializeField] GameObject parentAnimator;
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = parentAnimator.GetComponent<Animator>();
    }
   
    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Player"))
        {
            myAnimator.SetBool("Open", true);            
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            myAnimator.SetBool("Open", false);   
        }
    }
}
