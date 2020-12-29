using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LoadScreenBehaviour : MonoBehaviour
{
    [SerializeField]
    TMPro.TextMeshProUGUI text;

    [SerializeField]
    string loadText;

    int count = 1;

    float wait = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        wait += Time.fixedDeltaTime;

        if(wait > 0.5)
        {
            wait = 0;
            string t = loadText;

            for (int i = 0; i < count; i++)
            {
                t += ".";
            }

            text.text = t;

            count++;

            if (count > 3) { count = 1; }
        }
        
    }
}
