using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Inventory : MonoBehaviour
{
    private SteamVR_Action_Boolean _putInInventoryAction = SteamVR_Input.GetAction<Valve.VR.SteamVR_Action_Boolean>("PutInInventory");
    private Player _player = null;

    private Dictionary<RecyclableObject.ObjID, int> _inventory = new Dictionary<RecyclableObject.ObjID, int>();

    public Dictionary<RecyclableObject.ObjID, int> GetInventory { get { return _inventory; } }
    // Start is called before the first frame update
    void Start()
    {
        _player = Player.instance;

        if (_player == null)
        {
            Debug.LogError("<b>[SteamVR Interaction]</b> Teleport: No Player instance found in map.", this);
            Destroy(this.gameObject);
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check if the button required to put in inventory gets pressed
        foreach (Hand hand in _player.hands)
        {
            if (WasButtonPressed(hand) && hand.currentAttachedObject != null)
            {
                IncreaseInventory(hand);
            }
        }
    }

    private void IncreaseInventory(Hand hand)
    {
        //If yes, detach and eliminate object and increase inventory of that objects
        GameObject currentObj = hand.currentAttachedObject;
        RecyclableObject current = currentObj.GetComponent<RecyclableObject>();
        if (_inventory.TryGetValue(current.ID, out int count))
        {
            _inventory[current.ID] = count + 1;
        }
        else
        {
            _inventory.Add(current.ID, 1);
        }
        hand.DetachObject(currentObj);
        Destroy(currentObj);

        PrintLog();
    }

    internal void UpdateInventory(RecyclableObject.ObjID key, int used)
    {
        _inventory.TryGetValue(key, out int value);

        _inventory[key] = value - used;
        PrintLog();
    }

    private bool WasButtonPressed(Hand hand)
    {
        if (hand.noSteamVRFallbackCamera != null)
        {
            return Input.GetKey(KeyCode.J);
        }
        else
        {
            return _putInInventoryAction.GetStateDown(hand.handType);
        }
    }

    private void PrintLog()
    {
        //foreach (KeyValuePair<RecyclableObject.ObjID, int> pair in _inventory)
        //{
        //    UnityEngine.Debug.Log(pair.Value + " of " + pair.Key.trashType + " " + pair.Key.objectType);
        //} 
    }
}
