using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    [SerializeField]
    private Transform _raycast;

    private bool _previousStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!_animator)
            _animator = this.gameObject.GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        int layerMask = 1 << 3;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_raycast.position, _raycast.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            _animator.SetBool("Active", true);
        }
        else
        {
            _animator.SetBool("Active", false);
        }

        if(!_previousStatus && _animator.GetBool("Active"))
            EventManager.FirePlayerInteraction(this.gameObject); //fire event only the first time the ray hits the player
       
        _previousStatus = _animator.GetBool("Active");
    }
}
