using UnityEngine;

public class InventoryUI : MonoBehaviour {

    [SerializeField] private Inventory inventory;
    [SerializeField] private Transform slotsRootUI;
    [SerializeField] private Transform slotPrefabUI;

    private void Start() {
        inventory.OnInventoryUpdated += Inventory_OnInventoryUpdated;

        Inventory_OnInventoryUpdated();
    }

    private void Inventory_OnInventoryUpdated() {
        foreach (Transform child in slotsRootUI) {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < inventory.GetInventorySize(); i++) {
            Transform slotTransform = Instantiate(slotPrefabUI, slotsRootUI);
            if (slotTransform.TryGetComponent<SlotUI>(out SlotUI slotUI)) {
                slotUI.Setup(i, inventory);
            }
        }
    }
}