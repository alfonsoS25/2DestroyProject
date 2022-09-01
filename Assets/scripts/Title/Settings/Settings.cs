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
        Debug.Log("Saved: " + scroll.value + " at: " + SaveSlot);
        PlayerPrefs.SetFloat(SaveSlot, Value);
    }

    public void SaveParticleSettings(Scrollbar scroll, string SaveSlot)
    {
        float Value;
        Value = scroll.value * 800;
        Value += 200;
        Debug.Log("Saved: " + Value + " at: " + SaveSlot);
        PlayerPrefs.SetFloat(SaveSlot, Value);
        Debug.Log(PlayerPrefs.GetFloat(SaveSlot));
    }

    public void LoadSettings()
    {
        float BGMValue = PlayerPrefs.GetFloat("BGM");
        BGMScroll.value = BGMValue;

        float SEValue = PlayerPrefs.GetFloat("SE");
        SEScroll.value = SEValue;

        float ParticleValue = PlayerPrefs.GetFloat("Particles");
        Debug.Log(ParticleValue);
        Debug.Log(ParticleValue/800);
        ParticleScroll.value = (ParticleValue-200)/800;

    }
}
