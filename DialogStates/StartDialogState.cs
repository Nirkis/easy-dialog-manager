using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogState : IDialogState
{
    public void EnterState(DialogManager dialogManager)
    {
        Debug.Log("������ �������.");
        dialogManager.stageDialog = -1;
        dialogManager.StartUI();
        if (dialogManager.GetMaxState() == 0)
        {
            dialogManager.SetState(dialogManager.endState);
        }
        else
        {
            dialogManager.SetState(dialogManager.printingState);
        }
    }

    public void UpdateState(DialogManager dialogManager)    {    }
}
