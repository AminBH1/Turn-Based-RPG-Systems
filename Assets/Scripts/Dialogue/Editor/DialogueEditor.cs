using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class DialogueEditor : EditorWindow {


    [MenuItem("Window/Dialogue Editor")]
    public static void ShowDialogueEditor() {
        GetWindow(typeof(DialogueEditor), false, "DialogueEditor");
    }

    [OnOpenAsset(1)]
    public static bool OnAssetOpen(int instanceID, int line) {
        return true;
    }

}