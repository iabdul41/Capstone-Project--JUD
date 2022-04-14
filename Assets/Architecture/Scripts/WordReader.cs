using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordReader : MonoBehaviour
{
    public static WordReader Instance;
    [SerializeField] TextAsset correctWordText;
    //[SerializeField] TextAsset correctGuessText;

    List<string> correctWord;
    List<string> correctGuess;

    void Awake()
    {
        Instance = this;
        LoadFiles();
    }

    void LoadFiles()
    {
        correctWord = WordList.GetStrings(correctWordText);
        //correctGuess = WordBank.GetStrings(correctGuessText);
    }

    //Check if the word is in the WordBank

    public bool IsWordValid(string word)
    {
        return correctWord.Contains(word);// || correctGuessWords.Contains(word);
    }

    //Pick a random word when game starts

    public string GetRandomWord()
    {
        return correctWord[Random.Range(0, correctWord.Count)];
    }
}
