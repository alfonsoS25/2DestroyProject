using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class SaveSettings : MonoBehaviour, IPointerUpHandler
{
    [SerializeField]
    private string SaveSlotName;

    [SerializeField]
    private Scrollbar SettingScroll;

    [SerializeField]
    private Settings sett;

    [SerializeField]
    private bool IsParticlesSettings = false;

    [SerializeField]
    private Text textInput;

    [SerializeField]
    private AudioMixer audio;

    private void Start()
    {
        sett.LoadSettings();
        SettingScroll = GetComponent<Scrollbar>();
        UpdateText();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (IsParticlesSettings)
        {
            sett.SaveParticleSettings(SettingScroll, SaveSlotName);
        }
        else
        {   
            audio.SetFloat(SaveSlotName, Mathf.Log(Mathf.Clamp(SettingScroll.value,0.0001f,1)) * 20);
            sett.SaveSettings(SettingScroll, SaveSlotName);
        }
        UpdateText();
    }
    public void UpdateText()
    {
        textInput.text = SaveSlotName + ": " + (int)(SettingScroll.value * 100) + "%";
    }

}
