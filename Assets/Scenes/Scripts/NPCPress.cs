using UnityEngine;

public class NPCPress : MonoBehaviour
{
    public DialogueBox dialogueBox;
    public PlayerMovement playerMovement;

    void OnMouseDown()
    {
        // Called when this GameObjectís collider is clicked/tapped
        dialogueBox.ShowDialogue();
    }
}
