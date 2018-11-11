using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryItem : MonoBehaviour
{
    public enum itemSlots { primary, secondary }
    public enum handelStates { holstered, lowered, hip, raised, sighted }

    public itemSlots itemSlot;
    public bool duelWeildable;
    public handelStates handleState;
    [Space(10)]
    public Transform itemHandle;
    [Space(5)]
    public Transform[] stateMounts;
}
