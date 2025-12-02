using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {

    [SerializeField] private Image displayImage;
    [SerializeField] private TextMeshProUGUI amountText;

    private Inventory inventory;
    private InventoryItemSO itemSO;
    private int slotIndex;

    public void Setup(InventoryItemSO itemSO, Inventory inventory, int slotIndex) {
        this.itemSO = itemSO;
        this.inventory = inventory;
        this.slotIndex = slotIndex;
        SetVisual();
    }

    private void SetVisual() {
        if (itemSO == null) {
            displayImage.enabled = false;
            displayImage.sprite = null;
        } else {
            displayImage.enabled = true;
            displayImage.sprite = itemSO.GetDisplayIcon();
            amountText.text = inventory.GetAmountInSlot(slotIndex).ToString();
        }
    }
}
