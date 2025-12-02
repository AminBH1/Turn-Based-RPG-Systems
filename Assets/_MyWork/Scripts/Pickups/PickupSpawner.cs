using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    [SerializeField] private InventoryItemSO inventoryItemSO;
    [SerializeField] private int amount;

    private void Awake() {
        SpawnPickup();
    }

    private void SpawnPickup() {
        Pickup pickup = inventoryItemSO.SpawnPickup(transform, amount);
    }

}