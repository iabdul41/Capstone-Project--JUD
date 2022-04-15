using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //To set a fixed daily word
    [SerializeField] bool isDaily = false;

    [SerializeField] string correctGuessWord;
    string currentWord = "";

    bool isGameOver = false;

    //Number of tries in each game
    int tries = 5;


    WordReader wordReader;
    UIHandler uiHandler;
    WordManager wordManager;

    //Audio source
    AudioSource audioS;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        wordReader = FindObjectOfType<WordReader>();
        uiHandler = FindObjectOfType<UIHandler>();
        wordManager = FindObjectOfType<WordManager>();

        LetsPLay();

        audioS = Camera.main.GetComponent<AudioSource>();
        audioS.Play();
    }

    void LetsPLay()
    {
        isGameOver = false;

        if (isDaily)
        {
            Random.InitState(System.DateTime.Today.ToString().GetHashCode());
        }
            
        correctGuessWord = wordReader.GetRandomWord();
        wordManager.ClearStack();

        tries = 5;
        currentWord = "";
        isGameOver = false;
    }

    public void ResetGame()
    {
        if (isGameOver)
        {
            LetsPLay();
        }    
    }

    void NextTry()
    {
        for (int i = 0; i < 4; i++)
        {
            if (IsCorrectPlace(i))
            {
                wordManager.SetLetterStackColor(i, ColorManager.GetCorrectPlace());
            }


            else
            if (IsCorrectLetter(i))
            {
                wordManager.SetLetterStackColor(i, ColorManager.GetCorrectLetter());
            }

        }

        wordManager.NextStack();

        currentWord = "";

        //Next try after first guess
        tries--; 

        //Game to end after last try and wrong guess
        if (tries == 0)
        {
            GameLost();
        }


    }
    
    void GameWon()
    {
        isGameOver = true;
        uiHandler.DisplayGameWon();
        wordManager.StackLetterInCorrectPlaceColor();
    }

    
    void GameLost()
    {
        isGameOver = true;
        uiHandler.DisplayGameLost(correctGuessWord.ToUpper());
    }

    public void AddLetter(string letter)
    {
        if (isGameOver) return;

        if (currentWord.Length < 6)
        {
            letter = letter.ToLower();
            currentWord += letter;
            wordManager.AddStackLetter(letter);
        }
    }

    public void DeleteLetter()
    {
        if (isGameOver) return;

        if (currentWord.Length > 0)
        {
            currentWord = currentWord.Remove(currentWord.Length - 1);
            wordManager.DeleteLastStackLetter();
        }
    }

    public void SubmitWord()
    {
        if (isGameOver) return;

        //Word is less than 6 letters
        if (currentWord.Length < 6)
        {
            uiHandler.DisplayIncompleteWord();
            return;
        }

        //Word is not correct
        if (!wordReader.IsWordValid(currentWord))
        {
            uiHandler.DisplayIncorrectWord();
            return;
        }

        if (currentWord == correctGuessWord)
            GameWon();
        else
            NextTry();
    }

    public bool IsCorrectPlace(int index)
    {
        return currentWord[index] == correctGuessWord[index];
    }
    public bool IsCorrectLetter(int index)
    {
        return correctGuessWord.Contains(currentWord[index].ToString());
    }
}
