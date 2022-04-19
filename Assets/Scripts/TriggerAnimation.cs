using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] 
    private Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        if (!myAnimator)
        myAnimator = this.gameObject.GetComponent<Animator>();
    }
   
    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Player"))
        {
            myAnimator.SetBool("Active", true);            
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        if (other.CompareTag("Player"))
        {
            myAnimator.SetBool("Active", false);   
        }
    }
}
