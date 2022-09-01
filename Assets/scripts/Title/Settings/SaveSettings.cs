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

    private void Start()
    {
        SettingScroll = GetComponent<Scrollbar>();
    }


    public void OnPointerUp(PointerEventData eventData)
    {

        if (IsParticlesSettings)
        {
            sett.SaveParticleSettings(SettingScroll, SaveSlotName);
        }
        else
        {
            Debug.Log("equisde");
            sett.SaveSettings(SettingScroll, SaveSlotName);
        }
    }
}
