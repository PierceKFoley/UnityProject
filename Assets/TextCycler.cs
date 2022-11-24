using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextCycler : MonoBehaviour
{

    public TMPro.TMP_Text textField;
    public List<string> textEntries = new List<string>();
    public bool typewriter = false;
    public float typewriterIncrement;
    public string displayText = "";
    public int currentCount = 0;
    public bool blockCycleAtMax = false;

    public UnityEvent onReachLast = new UnityEvent();

    bool reachedLast = false;

    void Start()
    {
        if(textEntries.Count >= 1)
        {
            displayText = textEntries[currentCount];
            
        }
    }

    public void CycleForward()
    {
        if ((currentCount + 1) == textEntries.Count) 
        {
            if(!reachedLast)
                onReachLast?.Invoke();
            reachedLast = true;
            if (blockCycleAtMax)
                return;
        }

        if (currentCount < textEntries.Count)
        {
            currentCount += 1;
        } else
        {
            currentCount = 0;
        }

        DisplayText();
    }

    public void CycleBackwards()
    {
        if (currentCount > 0)
        {
            currentCount -= 1;
        }
        else
        {
            currentCount = textEntries.Count - 1;
        }

        DisplayText();
    }

    void DisplayText()
    {
        if (typewriter)
        {
            StopAllCoroutines();
            StartCoroutine(Typewrite(textEntries[currentCount], typewriterIncrement));
        }
        else
        {
            displayText = textEntries[currentCount];
            UpdateTextField();
        }
    }

    void UpdateTextField()
    {
        textField.text = displayText;
    }

    IEnumerator Typewrite(string str, float increment)
    {
        displayText = "";
        foreach(char c in str)
        {
            displayText += c;
            UpdateTextField();
            yield return new WaitForSeconds(increment); 
        }
    }
}
