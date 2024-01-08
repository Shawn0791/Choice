using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public int typeIndex;
    public NoteType noteType;
    public enum NoteType
    {
        Do, Re, Mi, Fa, So, La, Ti,
    }

    private void Start()
    {
        switch (noteType)
        {
            case NoteType.Do:
                typeIndex = 0;
                break;
            case NoteType.Re:
                typeIndex = 1;
                break;
            case NoteType.Mi:
                typeIndex = 2;
                break;
            case NoteType.Fa:
                typeIndex = 3;
                break;
            case NoteType.So:
                typeIndex = 4;
                break;
            case NoteType.La:
                typeIndex = 5;
                break;
            case NoteType.Ti:
                typeIndex = 6;
                break;
        }
    }

    public void ChangeColor()
    {
        GetComponent<Image>().color = Color.white;
    }
}
