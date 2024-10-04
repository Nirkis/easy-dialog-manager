using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    [Header("Dialog Settings")]
    [SerializeField] private DialogLine file; // Holds the reference to the dialog file containing the dialog lines
    [SerializeField] private float speedTalk = 0.04f; // The speed at which each character is printed
    public int stageDialog = -1; // Tracks the current stage of the dialog
    private Coroutine typingCoroutine; // Used to handle the typing coroutine
    [SerializeField] public bool isPrinting; // Flag to track whether text is being printed

    public IDialogState startState = new StartDialogState(); // State representing the start of the dialog
    public IDialogState printingState = new PrintingDialogState(); // State for when text is being printed
    public IDialogState waitingState = new WaitingDialogState(); // State representing waiting for user input after text is printed
    public IDialogState endState = new EndDialogState(); // State representing the end of the dialog
    private IDialogState currentState; // The current state of the dialog manager

    [Header("UI Elements")]
    [SerializeField] private GameObject dialogPanel; // UI panel containing the dialog elements
    [SerializeField] private TextMeshProUGUI talkTextField; // UI element to display the dialog text
    [SerializeField] private TextMeshProUGUI nameTextField; // UI element to display the character's name
    [SerializeField] private Image iconCharacter; // UI element to display the character's avatar
    [SerializeField] private AudioSource soundTalkSource; // Audio source for character dialogue sounds

    void Start()
    {
        SetState(endState); // Initialize the dialog with the end state
    }

    public bool IsUIActive()
    {
        return dialogPanel.activeSelf; // Check if the dialog panel is active
    }

    public void StartUI()
    {
        dialogPanel.SetActive(true); // Enable the dialog UI panel
    }

    public void StartNewDialog(string text)
    {
        if (!isPrinting) {
            if (typingCoroutine != null) // Force-stop the typing coroutine if starting a new dialog line
            {
                StopCoroutine(typingCoroutine);
            }
            isPrinting = false;
            typingCoroutine = StartCoroutine(PrintingTypeText(text)); // Start typing the new dialog line
        }
    }

    /*
    public void StartNewDialog(DialogLine newFile)
    {
        file = newFile;
        dialogPanel.SetActive(true); // Activate the dialog panel
        stageDialog = 0; // Set the dialog stage to the first line
        if (typingCoroutine != null) // Force-stop the typing coroutine if starting a new dialog line
        {
            StopCoroutine(typingCoroutine);
        }
        isPrinting = false;
        typingCoroutine = StartCoroutine(PrintingTypeText(file.LineOfDilog[stageDialog].text)); // Start typing the new dialog line
    }*/

    public IEnumerator PrintingTypeText(string text)
    {
        if (isPrinting) yield break; // Do not start a coroutine if text is already being printed
        isPrinting = true;
        talkTextField.text = ""; // Clear the text field before starting the typing
        nameTextField.text = file.LineOfDilog[stageDialog].cher.name_cherecter; // Set the character name in the UI
        iconCharacter.sprite = file.LineOfDilog[stageDialog].cher.avatar_image; // Set the character avatar in the UI
        yield return new WaitForSecondsRealtime(speedTalk); // Wait before starting the typing

        foreach (char letter in text.ToCharArray())
        {
            talkTextField.text += letter; // Add each character to the text field
            yield return new WaitForSecondsRealtime(speedTalk); // Wait between characters
        }
        isPrinting = false;
        SetState(waitingState); // Transition to the waiting state after printing is complete
    }

    public void NextStage()
    {
        if (!isPrinting) // Transition to the next dialog stage only if printing is finished
        {
            if (stageDialog < file.LineOfDilog.Count - 1)
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine); // Stop the previous typing coroutine if it exists
                }
                typingCoroutine = StartCoroutine(PrintingTypeText(file.LineOfDilog[stageDialog].text)); // Start typing the next stage of dialog
            }
            else
            {
                EndDialog(); // End the dialog if no more stages are left
            }
        }
    }

    public string GetStringNow()
    {
        return file.LineOfDilog[stageDialog].text; // Get the current dialog line text
    }

    public int GetMaxState()
    {
        return file.LineOfDilog.Count; // Get the total number of dialog stages
    }

    public void EndPrintingText(string text)
    {
        StopCoroutine(typingCoroutine); // Stop the typing coroutine
        talkTextField.text = text; // Set the full text immediately
    }

    public void EndDialog()
    {
        dialogPanel.SetActive(false); // Deactivate the dialog UI panel
    }

    void Update()
    {
        currentState.UpdateState(this); // Call the current state's update logic
    }

    public void SetState(IDialogState newState)
    {
        currentState = newState; // Switch to the new state
        currentState.EnterState(this); // Call the new state's entry logic
    }
}
