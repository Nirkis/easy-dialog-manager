using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDialogState : IDialogState
{
    public void EnterState(DialogManager dialogManager)
    {
        Debug.Log("������ �����.");
        dialogManager.EndDialog();
    }

    public void UpdateState(DialogManager dialogManager)    {    }
}
