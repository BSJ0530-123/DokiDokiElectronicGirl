using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    public AudioSource BGM_AudioSource;
    public AudioSource SFX_AudioSource;
    
    public Slider BgmSlider;
    public Slider SfxSlider;

    public void SetBgmVolume()
    {
        BGM_AudioSource.volume = BgmSlider.value;
    }
    
    public void SetSfxVolme()
    {
        SFX_AudioSource.volume = SfxSlider.value;
    }
}
