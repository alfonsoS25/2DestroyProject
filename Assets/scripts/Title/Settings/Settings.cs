using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    [SerializeField]
    private Scrollbar BGMScroll;
    [SerializeField]
    private Scrollbar SEScroll;
    [SerializeField]
    private Scrollbar ParticleScroll;

    public void SaveSettings(Scrollbar scroll, string SaveSlot)
    {
        float Value;
        Value = scroll.value;
        PlayerPrefs.SetFloat(SaveSlot, Value);
    }

    public void SaveParticleSettings(Scrollbar scroll, string SaveSlot)
    {
        float Value;
        Value = scroll.value * 800;
        Value += 200;
        PlayerPrefs.SetFloat(SaveSlot, Value);
    }

    public void LoadSettings()
    {
        float ParticleValue = PlayerPrefs.GetFloat("Particles");
        ParticleScroll.value = (ParticleValue - 200) / 800;
        Debug.Log("particle value: " + ParticleScroll.value);

        float BGMValue = PlayerPrefs.GetFloat("BGM");
        BGMScroll.value = BGMValue;

        float SEValue = PlayerPrefs.GetFloat("SE");
        SEScroll.value = SEValue;
    }
}
