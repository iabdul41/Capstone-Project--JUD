using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class controls the word stack in each row
public class WordStack : MonoBehaviour
{
    [SerializeField] List<LetterStack> lettersList;

    void Awake()
    {
        ClearStack();
    }
    
    public void SetLetterStackColor(int stackId, Color color)
    {
        lettersList[stackId].SetStackColor(color);
    }

    public void SetLetterStackText(int stackId, string letter)
    {
        lettersList[stackId].SetStackText(letter);
    }

    public void ClearStack()
    {
        foreach (var n in lettersList)
            n.ClearStack();
    }


}
