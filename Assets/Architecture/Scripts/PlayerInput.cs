using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour
{
    private List<KeyCode> validInput = new List<KeyCode>
    {
        KeyCode.A,
        KeyCode.B,
        KeyCode.C,
        KeyCode.D,
        KeyCode.E,
        KeyCode.F,
        KeyCode.G,
        KeyCode.H,
        KeyCode.I,
        KeyCode.J,
        KeyCode.K,
        KeyCode.L,
        KeyCode.M,
        KeyCode.N,
        KeyCode.O,
        KeyCode.P,
        KeyCode.Q,
        KeyCode.R,
        KeyCode.S,
        KeyCode.T,
        KeyCode.U,
        KeyCode.V,
        KeyCode.W,
        KeyCode.X,
        KeyCode.Y,
        KeyCode.Z,
    };

    //Audio source
    AudioSource audioS;
    public AudioClip tapSound;

    private void Start()
    {
        audioS = Camera.main.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            //To play sound on each word tap
            audioS.PlayOneShot(tapSound);

            if (Input.GetKeyDown(KeyCode.Delete) || Input.GetKeyDown(KeyCode.Backspace))
                DeleteLetter();
            else
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
                SubmitWord();
            else
            if (Input.GetKeyDown(KeyCode.Space))
                ResetGame();
            else
                foreach (KeyCode keyCode in validInput)
                    if (Input.GetKeyDown(keyCode))
                    {
                        AddLetter(keyCode.ToString());
                        break;
                    }
        }
    }
    void DeleteLetter()
    {
        GameManager.Instance.DeleteLetter();
    }

    void ResetGame()
    {
        GameManager.Instance.ResetGame();
    }

    void SubmitWord()
    {
        GameManager.Instance.SubmitWord();
    }

    void AddLetter(string letter)
    {
        GameManager.Instance.AddLetter(letter);
    }
}
    

