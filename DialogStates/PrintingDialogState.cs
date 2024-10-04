using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintingDialogState : IDialogState
{
    public void EnterState(DialogManager dialogManager)
    {
        ++dialogManager.stageDialog;
        Debug.Log("Диалог печатается:" + dialogManager.stageDialog.ToString());
        dialogManager.StartNewDialog(dialogManager.GetStringNow());
    }

    public void UpdateState(DialogManager dialogManager) { }
}
