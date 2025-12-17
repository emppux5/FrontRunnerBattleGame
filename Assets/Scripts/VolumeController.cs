using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource musicSource;
    public Slider volumeSlider;
    public Toggle muteToggle;

    float lastVolume = 1f;

    void Start()
    {
        // Varmistetaan aloitusääni
        musicSource.volume = 1f;

        // Synkataan slider ilman eventtiä
        volumeSlider.SetValueWithoutNotify(musicSource.volume);

        // Kytketään slider
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Kytketään mute toggle
        muteToggle.onValueChanged.AddListener(SetMute);
    }

    void SetVolume(float value)
    {
        if (value > 0f)
        {
            lastVolume = value;
            if (muteToggle.isOn)
                muteToggle.SetIsOnWithoutNotify(false);
        }

        musicSource.volume = value;
    }

    void SetMute(bool isMuted)
    {
        if (isMuted)
        {
            lastVolume = musicSource.volume;
            musicSource.volume = 0f;
            volumeSlider.SetValueWithoutNotify(0f);
        }
        else
        {
            musicSource.volume = lastVolume;
            volumeSlider.SetValueWithoutNotify(lastVolume);
        }
    }
}
