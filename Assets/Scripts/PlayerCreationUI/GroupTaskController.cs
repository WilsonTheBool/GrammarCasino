using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroupTaskController: MonoBehaviour
{
    [SerializeField]
    protected List<GroupTaskToggleHolder> groupTaskToggles;

    [SerializeField]
    protected GroupTaskToggleHolder prefab;

    [SerializeField]
    protected Transform contentTransform;

    [SerializeField]
    protected TaskController taskController;

    protected virtual void  Start()
    {
        groupTaskToggles = new List<GroupTaskToggleHolder>();

        string[] result = taskController.GetAllTaskGroups();

        AddNewGroupHolder(result);
    }

    public virtual void AddNewGroupHolder(string name)
    {
        GroupTaskToggleHolder holder = Instantiate(prefab.gameObject, contentTransform).GetComponent<GroupTaskToggleHolder>();
        
        holder.SetName(name);
        groupTaskToggles.Add(holder);
    }

    public virtual void AddNewGroupHolder(string[] names)
    {
        foreach(string name in names)
        {
            GroupTaskToggleHolder holder = Instantiate(prefab.gameObject, contentTransform).GetComponent<GroupTaskToggleHolder>();
            holder.SetName(name);
            groupTaskToggles.Add(holder);
        }
    }

    public virtual string[] GetActivatedGroups()
    {
        List<string> result = new List<string>();
        
        foreach(GroupTaskToggleHolder holder in groupTaskToggles)
        {
            if (holder.GetBool())
            {
                result.Add(holder.GetName());
            }
        }

        return result.ToArray();
    }
}

