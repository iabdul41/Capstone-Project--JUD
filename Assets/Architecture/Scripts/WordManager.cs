using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [SerializeField] List<WordStack> wordStackList;

    int letterIndex = 0;
    int wordIndex = 0;
    

    public void NextStack()
    {
        letterIndex = 0;
        wordIndex++;
    }

    public void ClearStack()
    {
        letterIndex = 0;
        wordIndex = 0;

        foreach (var n in wordStackList)
            n.ClearStack();
    }

    public void StackLetterInCorrectPlaceColor()
    {
        for (int i = 0; i < 6; i++)
            SetLetterStackColor(i, ColorManager.GetCorrectPlace());
    }

    public void AddStackLetter(string letter)
    {
        wordStackList[wordIndex].SetLetterStackText(letterIndex, letter.ToUpper());
        letterIndex++;
    }
    public void DeleteLastStackLetter()
    {
        letterIndex--;
        wordStackList[wordIndex].SetLetterStackText(letterIndex, "");
    }

    public void SetLetterStackColor(int index, Color color)
    {
        wordStackList[wordIndex].SetLetterStackColor(index, color);
    }
}
