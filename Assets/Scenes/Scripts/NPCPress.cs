using UnityEngine;

public class NPCPress : MonoBehaviour
{
    public DialogueBox dialogueBox;

    void OnMouseDown()
    {
        // Called when this GameObjectís collider is clicked/tapped
        dialogueBox.ShowDialogue();
    }
}
