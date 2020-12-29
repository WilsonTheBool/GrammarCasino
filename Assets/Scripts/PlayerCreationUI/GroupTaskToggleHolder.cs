using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GroupTaskToggleHolder : MonoBehaviour
{
    [SerializeField]
    private Toggle toggle;
    [SerializeField]
    private Text nameText;
    
    public void SetName(string name)
    {
        nameText.text = name;
    }

    public string GetName()
    {
        return nameText.text;
    }

    public bool GetBool()
    {
        return toggle.isOn;
    }
}
