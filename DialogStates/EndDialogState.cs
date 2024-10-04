using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogState : IDialogState
{
    public void EnterState(DialogManager dialogManager)
    {
        Debug.Log("Диалог конец.");
        dialogManager.EndDialog();
    }

    public void UpdateState(DialogManager dialogManager)    {    }
}
