using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class RecyclableObject : MonoBehaviour
{
    [SerializeField]
    private Enums.TrashType _trashType;
    [SerializeField]
    private Enums.ObjectType _objectType;

    public Enums.TrashType TrashType { get { return _trashType; } private set { _trashType = value; } }
    public Enums.ObjectType ObjectType { get { return _objectType; } private set { _objectType = value; } }

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        TrashCan can = other.gameObject.GetComponent<TrashCan>();
        if (can != null && can.TrashType.Contains(this.TrashType))
        {
            EventManager.FireCorrectRecycling(TrashType, ObjectType);
            UnityEngine.Debug.Log("correct!");
        }
        else
        {
            EventManager.FireWrongRecycling();
            UnityEngine.Debug.Log("wrooong!");
        }
    }
}
