using UnityEngine;
using UnityEngine.UI;
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
    private Text TextInput;

    private void Start()
    {
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
            sett.SaveSettings(SettingScroll, SaveSlotName);
        }
        UpdateText();
    }
    private void UpdateText()
    {
        Debug.Log(SettingScroll.value);
        TextInput.text = SaveSlotName + ": " + SettingScroll.value * 100 + "%";
    }
}
