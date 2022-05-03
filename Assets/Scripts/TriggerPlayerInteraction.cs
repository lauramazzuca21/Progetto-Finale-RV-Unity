using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerInteraction : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    [SerializeField]
    private Transform _raycast;

    private bool _previousStatus = false;

    private void FixedUpdate()
    {
        // Does the ray intersect the player layer
        int layerMask = 1 << 3;
        bool currentStatus = Physics.Raycast(_raycast.position, _raycast.TransformDirection(Vector3.forward), out RaycastHit hit, 3.0f, layerMask);

        if (_animator)
            _animator.SetBool("Active", currentStatus);

        if (!_previousStatus && currentStatus)
            EventManager.FirePlayerInteraction(this.gameObject); //fire event only the first time the ray hits the player
       
        _previousStatus = currentStatus;
    }
}
