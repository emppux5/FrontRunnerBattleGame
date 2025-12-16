using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle muteToggle;

    float lastVolume = 1f;

    void Start()
    {
        // Ladataan tallennetut asetukset
        float volume = PlayerPrefs.GetFloat("Volume", 1f);
        bool muted = PlayerPrefs.GetInt("Muted", 0) == 1;

        volumeSlider.value = volume;
        muteToggle.isOn = muted;

        ApplyVolume();
    }

    public void OnVolumeChanged(float value)
    {
        PlayerPrefs.SetFloat("Volume", value);

        if (!muteToggle.isOn)
            ApplyVolume();
    }

    public void OnMuteChanged(bool mute)
    {
        PlayerPrefs.SetInt("Muted", mute ? 1 : 0);

        if (mute)
        {
            lastVolume = volumeSlider.value;
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = lastVolume;
            volumeSlider.value = lastVolume;
        }
    }

    void ApplyVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
