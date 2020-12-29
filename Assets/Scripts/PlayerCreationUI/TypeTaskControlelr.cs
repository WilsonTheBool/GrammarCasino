using UnityEngine;
using System.Collections.Generic;

public class TypeTaskControlelr : GroupTaskController
{

    protected override void Start()
    {
        groupTaskToggles = new List<GroupTaskToggleHolder>();

        string[] result = taskController.GetAllTaskTypes();

        AddNewGroupHolder(result);
    }
}
