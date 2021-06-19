using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    private AudioSource audioSrc;
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;

    void Awake()
    {

        ContinueSettings();
    }

    private void ContinueSettings()
    {
        audioSrc = gameObject.GetComponent<AudioSource>();
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);

        backgroundAudio.volume = backgroundFloat;
        audioSrc.volume = soundEffectsFloat;
    }


    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioClip audioClip;
    }

}
