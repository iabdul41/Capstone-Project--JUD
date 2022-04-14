using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//This class controls the letter stack in each set of letters
public class LetterStack : MonoBehaviour
{
    [SerializeField] Image stackImage;
    [SerializeField] TextMeshProUGUI stackText;

    public void SetStackColor(Color color)
    {
        stackImage.color = color;
    }

    
    public void SetStackText(string letter)
    {
        stackText.text = letter;
    }
        
    public void ClearStack()
    {
        SetStackColor(ColorManager.GetIncorrectLetter());
        stackText.text = "";
    }
}
