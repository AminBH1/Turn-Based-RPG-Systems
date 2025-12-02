using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogueHandler : MonoBehaviour {

    public event Action OnDialogueUpdated;

    private DialogueSO dialogueStarted;
    private NPCSpeaker NPCSpeaker;
    private DialogueNodeSO currentNode;

    private bool isPlayerSpeaking;
    private bool isActiveDialogue;

    public void StartDialogue(DialogueSO dialogueStarted, NPCSpeaker NPCSpeaker) {
        this.dialogueStarted = dialogueStarted; 
        this.NPCSpeaker = NPCSpeaker;
        currentNode = dialogueStarted.GetRootNode();
        isActiveDialogue = true;
        OnDialogueUpdated?.Invoke();
    }

    private void Quit() {
        NPCSpeaker = null;
        currentNode = null;
        dialogueStarted = null;
        isPlayerSpeaking = false;
        isActiveDialogue = false;
        OnDialogueUpdated?.Invoke();
    }

    public bool IsActiveDialogue() {
        return isActiveDialogue;
    }

    public bool IsPlayerSpeaking() {
        return isPlayerSpeaking;
    }

    public IEnumerable<DialogueNodeSO> GetChoiceNodeList() {
        return dialogueStarted.GetChoiceNodeList(currentNode);
    }

    public DialogueNodeSO GetCurrentNode() {
        return currentNode;
    }

    public string GetNPCName() {
        return NPCSpeaker.GetNPCName();
    }

    public bool HasNext() {
        if (dialogueStarted.GetChildNodeList(currentNode).Count() == 0) {
            return false;
        }
        return true;
    }
    public void SelectChoice(DialogueNodeSO choiceNode) {
        currentNode = choiceNode;
        isPlayerSpeaking = false;
        if (HasNext()) {
            Next();
        } else {
            Quit();
        }
    }

    public void Next() {
        if (HasChoiceNode(currentNode)) return;
      
        DialogueNodeSO nextNode = dialogueStarted.GetNPCNodeList(currentNode).ToArray()[0];
        currentNode = nextNode;

        if (HasChoiceNode(nextNode)) return;

        OnDialogueUpdated?.Invoke();
    }

    private bool HasChoiceNode(DialogueNodeSO parentNode) {
        if (dialogueStarted.GetChoiceNodeList(parentNode).Count() > 0) {
            isPlayerSpeaking = true;
            OnDialogueUpdated?.Invoke();
            Debug.Log(parentNode);
            return true;
        }
        return false;
    }
}