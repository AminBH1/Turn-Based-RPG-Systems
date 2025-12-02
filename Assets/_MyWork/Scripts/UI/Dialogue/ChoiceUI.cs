using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceUI : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI choiceText;
    [SerializeField] private Button choiceButton;

    private DialogueNodeSO choiceNode;
    private DialogueHandler dialogueHandler;

    public void Setup(DialogueNodeSO choiceNode, DialogueHandler dialogueHandler) {
        this.choiceNode = choiceNode;
        this.dialogueHandler = dialogueHandler;

        choiceButton.onClick.AddListener(() => {
            dialogueHandler.SelectChoice(choiceNode);
        });

        SetVisual();
    }

    private void SetVisual() {
        choiceText.text = choiceNode.GetNodeText();
    }
}
