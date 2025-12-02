using System;
using UnityEngine;

public class NPCSpeaker : MonoBehaviour, IInteractable {

    [SerializeField] private DialogueHandler dialogueHandler;
    [SerializeField] private DialogueSO dialogueSO;
    [SerializeField] private string npcName;

    public void Interact() {
        dialogueHandler.StartDialogue(dialogueSO, this);
    }

    public string GetNPCName() {
        return npcName;
    }

}