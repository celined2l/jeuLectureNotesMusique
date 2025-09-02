using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public TMP_Dropdown clefDropdown;
    public TMP_Dropdown exerciceDropdown;
    public Slider tempoSlider;
    public Text tempoValueText;


    private void Start()
    {
        //forcer l'orientation en paysage
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        tempoSlider.onValueChanged.AddListener(OnTempoChanged);
        clefDropdown.onValueChanged.AddListener(OnClefChanged);
        exerciceDropdown.onValueChanged.AddListener(OnExerciceChanged);

        if (tempoValueText != null)
            tempoValueText.text = "Tempo: " + Mathf.RoundToInt(tempoSlider.value) + " BPM";
    }

    private void OnTempoChanged(float value)
    {
        if (tempoValueText != null)
            tempoValueText.text = "Tempo: " + Mathf.RoundToInt(value) + " BPM";
        Global.bpm = Mathf.RoundToInt(value);
    }

    // Cette méthode doit être reliée au bouton "Valider"
    public void surClick()
    {
        if (clefDropdown == null || tempoSlider == null || exerciceDropdown == null)
        {
            Debug.LogError("MenuManager: références manquantes (clefDropdown, exerciceDropdown ou tempoSlider).");
            return;
        }

        SceneManager.LoadScene("SceneJeu");
    }

    private void OnClefChanged(int value)
    {
        switch (value)
        {
            case 0: Global.currentClef = Global.ClefType.CleSol; break;
            case 1: Global.currentClef = Global.ClefType.CleFa; break;
            case 2: Global.currentClef = Global.ClefType.CleUt3; break;
        }
    }


    private void OnExerciceChanged(int value)
    {
        switch (value)
        {
            case 0: Global.currentModeExercice = Global.ModeExercice.ligne; break;
            case 1: Global.currentModeExercice = Global.ModeExercice.interligne; break;
            case 2: Global.currentModeExercice = Global.ModeExercice.mixte; break;
        }
    }

    // Cette méthode doit être reliée au bouton "Sortir"
    public void Quitter()
    {
        Application.Quit();
    }

}

