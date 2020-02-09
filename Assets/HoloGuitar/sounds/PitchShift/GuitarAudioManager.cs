using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class GuitarAudioManager : MonoBehaviour
{
    public AudioMixer TgtMixer;
    public float fluct;
    
    public void Start()
    {
        PitchReset();
    }
    public void PitchShift(float position)
    {
        fluct = fluct * position;
        string Strfluct = fluct.ToString();
        TgtMixer.SetFloat("MyExposedParam", fluct);
        Debug.Log("PitchShift! " + Strfluct) ;
    }

    public void PitchReset()
    {
        fluct = 1f;
        TgtMixer.SetFloat("MyExposedParam", fluct);
        Debug.Log("Reset Pitch!");
    }
}