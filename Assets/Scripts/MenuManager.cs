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

private void Awake()
    {
        // Si le dropdown n'est pas assigné, on va le chercher
        if (clefDropdown == null)
        {
            foreach (var d in FindObjectsOfType<TMP_Dropdown>())
            {
                if (d.name.Contains("Clef")) clefDropdown = d;
            }
        }

        if (exerciceDropdown == null)
        {
            foreach (var e in FindObjectsOfType<TMP_Dropdown>())
            {
                if (e.name.Contains("Exercice")) exerciceDropdown = e;
            }
        }

        // Si le slider n'est pas assigné, on va le chercher
        if (tempoSlider == null)
        {
            foreach (var s in FindObjectsOfType<Slider>())
            {
                if (s.name.Contains("Tempo")) tempoSlider = s;
            }
        }

        // Si le texte n'est pas assigné, on va le chercher
        if (tempoValueText == null)
        {
            foreach (var t in FindObjectsOfType<Text>())
            {
                if (t.name.Contains("Tempo")) tempoValueText = t;
            }
        }
    }

    private void Start()
    {
        if (tempoSlider != null)
            tempoSlider.onValueChanged.AddListener(OnTempoChanged);

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

        // PlayerPrefs.SetInt("Clef", clefDropdown.value);
        // PlayerPrefs.SetInt("Tempo", Mathf.RoundToInt(tempoSlider.value));
        SceneManager.LoadScene("SceneJeu");
    }
}