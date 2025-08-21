using UnityEngine;
using UnityEngine.UI;

public class TempoUI : MonoBehaviour
{
    public TempoManager tempoManager;
    public Slider bpmSlider;
    public Text bpmLabel;

    private void Start()
    {
        //if (tempoManager == null) tempoManager = GameObject.FindObjectOfType<TempoManager>();
        // if (bpmSlider != null)
        // {
        //     bpmSlider.minValue = 30f;
        //     bpmSlider.maxValue = 300f;
        //     bpmSlider.value = tempoManager != null ? tempoManager.bpm : 50;
        //     bpmSlider.onValueChanged.AddListener(OnSliderChanged);
        // }
        UpdateLabel();
    }

    private void OnSliderChanged(float val)
    {
        if (tempoManager != null) tempoManager.SetTempo(val); UpdateLabel();
    }

    private void UpdateLabel()
    {
        if (bpmLabel != null && tempoManager != null)
            bpmLabel.text = $"BPM: {Mathf.RoundToInt(Global.bpm)}";
    }
        
}
