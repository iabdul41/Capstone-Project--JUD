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

    //Audio source
    AudioSource audioS;
    public AudioClip gameLossAudio;
    public AudioClip gameWonAudio;

    private void Start()
    {
        audioS = Camera.main.GetComponent<AudioSource>();
    }

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

        audioS.PlayOneShot(gameWonAudio);
    }

    public void DisplayGameLost(string word)
    {
        GameLostText.text = "Word: " + word;
        GameLost.SetActive(true);

        audioS.PlayOneShot(gameLossAudio);
    }
}
