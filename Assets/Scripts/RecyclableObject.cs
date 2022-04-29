using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class RecyclableObject : MonoBehaviour
{
    [System.Serializable]
    public struct ObjID
    {
        public Enums.TrashType trashType;
        public Enums.ObjectType objectType;

        public override int GetHashCode()
        {
            const uint hash = 0x9e3779b9;
            var seed = trashType.GetHashCode() + hash;
            seed ^= objectType.GetHashCode() + hash + (seed << 6) + (seed >> 2);
            return (int)seed;
        }
        public override bool Equals(object obj)
        {
            return obj is ObjID other && (trashType == other.trashType && objectType == other.objectType);
        }
    };

    [SerializeField]
    private ObjID _id;

    public Enums.TrashType TrashType { get { return _id.trashType; } set { _id.trashType = value; } }
    public Enums.ObjectType ObjectType { get { return _id.objectType; } set { _id.objectType = value; } }
    public ObjID ID { get { return _id; } private set { _id = value; } }

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
