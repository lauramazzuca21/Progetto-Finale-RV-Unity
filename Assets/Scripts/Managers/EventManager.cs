using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //definisce la funzione che voglio (interfaccia funzione evento)
    public delegate void ReceivePoints(int pts);
    public static event ReceivePoints Points;

    public delegate void ReceiveSound(string objTag);
    public static event ReceiveSound Sound;

    public delegate void ReceiveCorrectRecycling(Enums.TrashType trashType, Enums.ObjectType objectType);
    public static event ReceiveCorrectRecycling CorrectRecycling;

    public delegate void ReceiveWrongRecycling();
    public static event ReceiveWrongRecycling WrongRecycling;


    internal static void FirePointsEvent(int pts)
    {
        Points?.Invoke(pts);
    }

    internal static void FireSoundEvent(string objTag)
    {
        Sound?.Invoke(objTag);
    }

    internal static void FireCorrectRecycling(Enums.TrashType trashType, Enums.ObjectType objectType)
    {
        CorrectRecycling?.Invoke(trashType, objectType);
    }

    internal static void FireWrongRecycling()
    {
        WrongRecycling?.Invoke();
    }
}
