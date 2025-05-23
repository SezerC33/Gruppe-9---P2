using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text dialogueText;
    public GameObject dialoguePanel;

    [Header("Dialogue Data")]
    [TextArea] public string[] lines;
    private int currentLine = 0;

    public PlayerMovement playerMovement; // Reference to the player movement script

    void Start()
    {
        // Hide on start, or set active based on your flow
        dialoguePanel.SetActive(false);
    }

    public void ShowDialogue()
    {
        if (lines.Length == 0) return;
        currentLine = 0;
        dialogueText.text = lines[currentLine];
        dialoguePanel.SetActive(true);
        if (playerMovement != null)
            playerMovement.enabled = false; // Disable movement when dialogue starts
    }

    // Call this (e.g. via button or Input) to advance
    public void NextLine()
    {
        currentLine++;
        if (currentLine < lines.Length)
        {
            dialogueText.text = lines[currentLine];
        }
        else
        {
            dialoguePanel.SetActive(false);
            if (playerMovement != null)
                playerMovement.enabled = true;  // Re-enable movement
        }
    }
}