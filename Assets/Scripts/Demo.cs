using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    //square brackets pick char in string from 0 to length - 1 including spaces.
    // someString = "cling"
    //someString[2] = i
    public Text displayText;

    string display;
    string original;

    public int charIndex = 0;

    public List<string> sourceStrings;
    int stringIndex = 0;

    public Text comboCounter;
    int combo = 0;

    // Start is called before the first frame update
    void Start()
    {
        original = sourceStrings[stringIndex];

        UnityEngine.InputSystem.Keyboard.current.onTextInput += OnTextInput;
    }

    private void OnTextInput(char obj)
    {
        if(obj == original[charIndex])
        {
            charIndex += 1;
            combo += 1;
            if (charIndex == original.Length)
            {
                charIndex = 0;
                stringIndex += 1;
                stringIndex = stringIndex % sourceStrings.Count;
                original = sourceStrings[stringIndex];
            }
            //if (original[index] == ' ') index += 1;
        }
        else
        {
            combo = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //"This is a string'
        //"0123456789
        string left = original.Substring(0, charIndex);
        string right = original.Substring(charIndex, original.Length - charIndex);
        display = string.Format("<color=red>{0}</color>{1}", left, right);
        displayText.text = display;
        comboCounter.text = "Combo: " + combo;
    }
}
