using UnityEngine;

public class NPCPress : MonoBehaviour
{
    public DialogueBox dialogueBox;
    public PlayerMovement playerMovement;

    void OnMouseDown()
    {
        // Called when this GameObject’s collider is clicked/tapped
        dialogueBox.ShowDialogue();
    }
}
