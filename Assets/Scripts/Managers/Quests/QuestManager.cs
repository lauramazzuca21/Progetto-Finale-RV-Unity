using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestManager : MonoBehaviour
{
    [SerializeField]
    private int _correctPoints = 0;
    [SerializeField]
    private int _wrongPoints = 0;
    [SerializeField]
    private Transform _raycast;
    [SerializeField]
    private Animator _NPCAnimator;

    protected int CorrectPoints { get { return _correctPoints; } set { _correctPoints = value; } }
    protected int WrongPoints { get { return _wrongPoints; } set { _wrongPoints = value; } }

    protected abstract void HandleCorrectRecycle(Enums.TrashType trashType, Enums.ObjectType objectType);
    protected abstract void HandleWrongRecycle();

    private void FixedUpdate()
    {
        int layerMask = 1 << 3;
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(_raycast.position, _raycast.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            _NPCAnimator.SetBool("Active", true);
        }
        else
        {
            _NPCAnimator.SetBool("Active", false);
        }
    }
}
