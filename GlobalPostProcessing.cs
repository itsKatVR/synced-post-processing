
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class GlobalPostProcessing : UdonSharpBehaviour
{
    public Slider volumeSlider;
    public PostProcessVolume volume;
    [UdonSynced(UdonSyncMode.Smooth)] public float syncedValue;

    void Start() { volumeSlider.SetValueWithoutNotify(volume.weight); }
    public override void OnDeserialization()
    {
        volumeSlider.SetValueWithoutNotify(syncedValue);
        volume.weight = syncedValue;
    }
    public void SetVolume()
    {
        Networking.SetOwner(Networking.LocalPlayer, gameObject);
        syncedValue = volumeSlider.value;
        volume.weight = syncedValue;
        RequestSerialization();
    }
}
