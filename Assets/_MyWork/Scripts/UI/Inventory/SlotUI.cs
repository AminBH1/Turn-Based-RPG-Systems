using System;
using UnityEngine;

public class SlotUI : MonoBehaviour {

    [SerializeField] private ItemUI itemUI;

    private int slotIndex;
    private Inventory Inventory;
    public void Setup(int i, Inventory inventory) {
        this.slotIndex = i;
        this.Inventory = inventory;     
        itemUI.Setup(inventory.GetItemSOInSlot(slotIndex), inventory, slotIndex);
    }

}