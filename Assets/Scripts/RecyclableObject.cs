using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RecyclableObject : MonoBehaviour
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
            return obj is ObjID other && ((trashType == other.trashType && objectType == other.objectType) || (trashType == other.trashType && this.objectType == Enums.ObjectType.ANY));
        }
    };

    [SerializeField]
    private ObjID _id;

    public Enums.TrashType TrashType { get { return _id.trashType; } set { _id.trashType = value; } }
    public Enums.ObjectType ObjectType { get { return _id.objectType; } set { _id.objectType = value; } }
    public ObjID ID { get { return _id; } private set { _id = value; } }
}
