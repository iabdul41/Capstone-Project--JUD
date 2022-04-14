using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    [SerializeField] GameObject incompleteWord;
    [SerializeField] GameObject incorrectWord;
    [SerializeField] GameObject GameWon;
    [SerializeField] GameObject GameLost;
    [SerializeField] TextMeshProUGUI GameLostText;

    public void DisplayIncompleteWord()
    {
        incompleteWord.SetActive(true);
    }

    public void DisplayIncorrectWord()
    {
        incorrectWord.SetActive(true);
    }

    public void DisplayGameWon()
    {
        GameWon.SetActive(true);
    }

    public void DisplayGameLost(string word)
    {
        GameLostText.text = "Word: " + word;
        GameLost.SetActive(true);
    }
}
