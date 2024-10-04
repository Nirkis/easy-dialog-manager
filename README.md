# easy-dialog-manager

easy-dialog-manager is a universal tool for creating interactive dialogues in Unity. The system provides smooth control of characters, dialog lines and the process of displaying text on the screen using a flexible state architecture.

## Main features:
- **Creating and managing characters:** Define names, sounds, and images of characters via ScriptableObject.
- **Dialog management:** Easily create dialogues with multiple lines of text and characters.
- **Support for different dialog states:** The system manages the states (beginning, text output, waiting and ending of the dialogue), providing convenient switching between the stages of the dialogue.
- **Integration with UI:** Easily customize the display of text and images in the Unity UI using TextMeshPro and other interface elements.

## Installation

1. Clone the repository and add a folder to your Unity project.
2. Add the necessary UI elements (panels, text fields, images) to the scene and link them to the fields in the `DialogManager`.

## Example of activate
StartDialog.cs:
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager; // Ссылка на менеджер диалогов
    [SerializeField] private DialogLine dialogFile; // Файл с диалогом

    private void Update()
    {
        // Активация диалога по нажатию кнопки TheAction
        if (Input.GetButtonDown("TheAction"))
        {
            // Если диалог ещё не запущен, запускаем его
            if (!dialogManager.IsUIActive())
            {
                dialogManager.SetState(dialogManager.startState);
                this.gameObject.SetActive(false);
            }
        }
    }
}

```
