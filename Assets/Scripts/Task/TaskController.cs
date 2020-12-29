using UnityEngine;
using System;
using System.Collections.Generic;


public class TaskController : MonoBehaviour
{
    public List<Task_TrueFalse> TrueFalseTasks;

    public List<Task_Test> TestTasks;

    /// <summary>
    /// задания выбранные при создании игры согласно треб. пользователя
    /// </summary>
    private List<TaskBase> loadedTasks;

    /// <summary>
    /// Доступные, еще НЕ разданные задания
    /// </summary>
    public List<TaskBase> allTasks;

    public Dictionary<string, bool> isTaskUsedDictinary;

    private void Awake()
    {
        loadedTasks = new List<TaskBase>();

        TrueFalseTasks = new List<Task_TrueFalse>(GetComponentsInChildren<Task_TrueFalse>());

        TestTasks = new List<Task_Test>(GetComponentsInChildren<Task_Test>());

    }
    
    /// <summary>
    /// (!!!!!) Переделать с сереиализацией и чтением из памяти
    /// </summary>
    public void LoadTasks(string[] groups, string[] types)
    {
        foreach (Task_TrueFalse task in TrueFalseTasks)
        {
            if(Array.LastIndexOf(groups, task.group) != -1 && Array.LastIndexOf(types, task.type) != -1)
            {
                loadedTasks.Add(task);
            }
        }

        foreach (Task_Test task in TestTasks)
        {
            if (Array.LastIndexOf(groups, task.group) != -1 && Array.LastIndexOf(types, task.type) != -1)
            {
                loadedTasks.Add(task);
            }
        }

        allTasks = new List<TaskBase>(loadedTasks);
    }

    public TaskBase GetRandomTask(int minLevel)
    {
        if(allTasks.Count > 0)
        {
            int randomPos = UnityEngine.Random.Range(0, allTasks.Count);

            TaskBase task = allTasks[randomPos];

            allTasks.RemoveAt(randomPos);

            return task;
        }
        else
        {
            RefreshAllTasks();
            return GetRandomTask(minLevel);
        }
    }



    private void RefreshAllTasks()
    {
        allTasks = new List<TaskBase>(loadedTasks);
    }

    public string[] GetAllTaskGroups()
    {
        List<string> groups = new List<string>();

        foreach(Task_TrueFalse task in TrueFalseTasks)
        {
            if (!groups.Contains(task.group))
            {
                groups.Add(task.group);
            }
        }

        foreach (Task_Test task in TestTasks)
        {
            if (!groups.Contains(task.group))
            {
                groups.Add(task.group);
            }
        }

        return groups.ToArray();
    }

    public string[] GetAllTaskTypes()
    {
        List<string> groups = new List<string>();

        foreach (Task_TrueFalse task in TrueFalseTasks)
        {
            if (!groups.Contains(task.type))
            {
                groups.Add(task.type);
            }
        }

        foreach (Task_Test task in TestTasks)
        {
            if (!groups.Contains(task.type))
            {
                groups.Add(task.type);
            }
        }

        return groups.ToArray();
    }
}
