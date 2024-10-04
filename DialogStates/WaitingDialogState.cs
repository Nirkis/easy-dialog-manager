using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingDialogState : IDialogState
{
    public void EnterState(DialogManager dialogManager)
    {
        Debug.Log("Диалог ждёт реакции.");
    }

    public void UpdateState(DialogManager dialogManager)
    {
		if (Input.GetButtonUp("TheAction"))
        {
            if (dialogManager.stageDialog >= dialogManager.GetMaxState()-1)
            {
                dialogManager.SetState(dialogManager.endState);
            }
			else
			{
                dialogManager.SetState(dialogManager.printingState);
			}
        }
    }
}
