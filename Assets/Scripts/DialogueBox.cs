using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TMP_Text dialogueText; // Reference to the TextMeshPro text component displaying dialogue
    public GameObject dialoguePanel; // The UI panel that contains the dialogue text
    [TextArea] public string[] lines; // Array of dialogue lines editable in the inspector
    private int currentLine = 0; // Tracks which line of dialogue is currently shown

    public PlayerMovement playerMovement; // Reference to the script controlling player movement

    void Start()
    {
        dialoguePanel.SetActive(false); // Hide the dialogue panel at the start
    }

    public void ShowDialogue() // Call this to begin showing the dialogue
    {
        if (lines.Length == 0) return; // If there are no lines, do nothing
        currentLine = 0; // Reset to the first line
        dialogueText.text = lines[currentLine]; // Display the first line of dialogue
        dialoguePanel.SetActive(true); // Show the dialogue panel
        if (playerMovement != null)
            playerMovement.enabled = false; // Disable player movement during dialogue
    }

    public void NextLine() // Call this (On button press) to advance dialogue
    {
        currentLine++; // Move to the next line
        if (currentLine < lines.Length) // If more lines remain
        {
            dialogueText.text = lines[currentLine]; // Update the displayed text
        }
        else // If no more lines
        {
            dialoguePanel.SetActive(false); // Hide the dialogue panel
            if (playerMovement != null)
                playerMovement.enabled = true; // Re-enable player movement
        }
    }
}