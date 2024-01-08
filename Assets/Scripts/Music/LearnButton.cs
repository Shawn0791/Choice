using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LearnButton : MonoBehaviour
{
    public ButtonType buttonType;
    public AudioClip sound;
    public enum ButtonType
    {
        Do,Re,Mi,Fa,So,La,Ti,
    }
    public int currentIndex;
    public void ButtonPressed()
    {
        MusicManager.instance.CheckCurrentMusic(currentIndex);

        AudioSource.PlayClipAtPoint(sound, Camera.main.transform.position);
    }
}
