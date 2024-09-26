using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{   
    public AudioSource audioSource;
    public Slider volume;
    private const string VolumePref = "VolumePref";

    private void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat(VolumePref, 1.0f);
        audioSource.volume = savedVolume;
        audioSource.Play();
        if (volume != null)
        {
            volume.value = savedVolume;
            volume.onValueChanged.AddListener(SetVolume);
        }
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat(VolumePref, volume);
        PlayerPrefs.Save();
    }

    public void ResetVolume()
    {
        SetVolume(1.0f);
        if (volume != null)
        {
            volume.value = 1.0f;
        }
    }
}
