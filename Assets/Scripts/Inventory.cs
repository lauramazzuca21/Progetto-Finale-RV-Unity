using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Inventory : MonoBehaviour
{
    private SteamVR_Action_Boolean _putInInventoryAction = SteamVR_Input.GetAction<Valve.VR.SteamVR_Action_Boolean>("PutInInventory");
    private Player _player = null;

    private Dictionary<Enums.ObjectType, int> _inventory = new Dictionary<Enums.ObjectType, int>();

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
        hand.currentAttachedObject.SetActive(false);
        RecyclableObject current = hand.currentAttachedObject.GetComponent<RecyclableObject>();
        if (_inventory.TryGetValue(current.ObjectType, out int count))
        {
            _inventory[current.ObjectType] = count + 1;
        }
        else
        {
            _inventory.Add(current.ObjectType, 1);
        }
        hand.DetachObject(hand.currentAttachedObject);
        DestroyImmediate(hand.currentAttachedObject);

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
        foreach (KeyValuePair< Enums.ObjectType, int> pair in _inventory)
        {
            UnityEngine.Debug.Log(pair.Value + " of " + pair.Key);
        }
    }
}
