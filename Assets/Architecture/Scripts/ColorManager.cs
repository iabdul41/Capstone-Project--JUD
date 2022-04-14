using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] Color incorrectLetter;
    [SerializeField] Color correctLetter;
    [SerializeField] Color correctPlace;

    static Color _incorrectLetter;
    static Color _correctLetter;
    static Color _correctPlace;

    private void Awake()
    {
        _incorrectLetter = incorrectLetter;
        _correctLetter = correctLetter;
        _correctPlace = correctPlace;
    }

    public static Color GetIncorrectLetter()
    {
        return _incorrectLetter;
    }
   
    public static Color GetCorrectLetter()
    {
        return _correctLetter;
    }

    
    public static Color GetCorrectPlace()
    {
        return _correctPlace;
    }
}
