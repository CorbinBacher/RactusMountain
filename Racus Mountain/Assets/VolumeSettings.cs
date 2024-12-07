using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
[SerializeField] private AudioMixer myMixer;
[SerializeField] private Slider musicSlider;
[SerializeField] private Slider masterSlider;

public void SetMusicVolume()
{
    float volume = musicSlider.value;
    myMixer.SetFloat("music", Mathf.Log10(volume) * 20);

}

public void SetMasterVolume()
{
    float volume = masterSlider.value;
    myMixer.SetFloat("master", Mathf.Log10(volume) * 20);

}
}
