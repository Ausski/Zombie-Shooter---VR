using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour {

    private enum handStates { empty,  };

    public bool leftHanded;
    [Space(10)]
    public Transform leftHandSlot;
    public Transform rightHandSlot;
    [Space(10)]
    public Transform[] slotItem;

    private bool weaponSighted = false;

    void Update()
    {
        ControlInventory();
        ControlHands();

        ManageItems();
        ManageStates();
    }


    void ControlInventory()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipSlot(1);
        }
    }

    void EquipSlot(int slot)
    {
        if (slotItem[slot])
        {
            Transform newItem = slotItem[slot];

            if (leftHanded)
            {
                leftHandSlot = newItem;
            }
            else
            {
                rightHandSlot = newItem;
            }
        }
    }


    void ControlHands()
    {
        if (Input.GetMouseButtonDown(1))
        {
            weaponSighted = !weaponSighted;
        }
    }


    void ManageItems()
    {
        for (int i = 0; i < slotItem.Length; i++)
        {
            Transform selectedItem = slotItem[i];

            inventoryItem itemProperties = selectedItem.GetComponent<inventoryItem>();
            Transform[] itemMounts = itemProperties.stateMounts;
            inventoryItem.handelStates itemState = itemProperties.handleState;
            int stateID = (int)itemState;

            Transform selectedMount = itemMounts[stateID];

            PositionItem(selectedItem, selectedMount);
        }
    }

    void PositionItem(Transform item, Transform mount)
    {
        inventoryItem itemProperties = item.GetComponent<inventoryItem>();
        Transform itemHandle = itemProperties.itemHandle;

        Vector3 mountPos = mount.localPosition;
        Vector3 mountRot = mount.localEulerAngles;

        Vector3 itemPos = mountPos;
        Vector3 itemRot = mountRot;

        int side = 1;

        if (item == leftHandSlot)
        {
            side = -1;
        }
        
        if (item == rightHandSlot)
        {
            side = 1;
        }

        itemPos = new Vector3(mountPos.x * side, mountPos.y, mountPos.z);
        itemRot = new Vector3(mountRot.x, mountRot.y * side, mountRot.z * side);

        itemHandle.localPosition = itemPos;
        itemHandle.localRotation = Quaternion.Euler(itemRot);
    }


    void ManageStates()
    {
        if (leftHanded)
        {

        }

        inventoryItem.handelStates leftHandState = leftHandSlot.GetComponent<inventoryItem>().handleState;
        inventoryItem.handelStates rightHandState = leftHandSlot.GetComponent<inventoryItem>().handleState;

        if (weaponSighted)
        {
            if (leftHanded)
            {
                leftHandState = inventoryItem.handelStates.sighted;
            }
            else
            {
                rightHandState = inventoryItem.handelStates.sighted;
            }
        }
        else
        {
            if (leftHanded)
            {
                leftHandState = inventoryItem.handelStates.raised;
            }
            else
            {
                rightHandState = inventoryItem.handelStates.raised;
            }
        }

        for (int i = 0; i < slotItem.Length; i++)
        {
            Transform selectedItem = slotItem[i];

            inventoryItem itemProperties = selectedItem.GetComponent<inventoryItem>();
            inventoryItem.handelStates itemState = itemProperties.handleState;

            if (selectedItem != leftHandSlot || rightHandSlot)
            {
                itemState = inventoryItem.handelStates.holstered;
            }
        }
    }
}
