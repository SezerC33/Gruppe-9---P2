using UnityEngine;

public class NPCPress : MonoBehaviour
{
    public DialogueBox dialogueBox;

    void OnMouseDown()
    {
        // Called when this GameObject’s collider is clicked/tapped
        dialogueBox.ShowDialogue();
    }
}
