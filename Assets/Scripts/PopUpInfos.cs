using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpInfos : MonoBehaviour
{
    public GameObject popupPanel;
    public Button boutonOK;
    public TMP_Text textNiveau;
    public TMP_Text notesNiveau;

    public TempoManager tempoManager;


    void Start()
    {
        popupPanel.SetActive(false);
        boutonOK.onClick.AddListener(FermerPopup);
               
    }


    public void AfficherPopup(string message)
    {
        popupPanel.SetActive(true);
        popupPanel.transform.localPosition = new Vector2(0, 0);

        string [] texte = new string[Global.currentExercice.Count] ;
        for (int i = 0; i < Global.currentExercice.Count; i++)
            texte[i] = Global.notesCleEnCours[Global.currentExercice[i]];

        notesNiveau.text = "Notes : " + string.Join(", ", texte);
        textNiveau.text = message;

        tempoManager.Pause("rien");
    }

    public void FermerPopup()
    {
        popupPanel.SetActive(false);
        tempoManager.Pause("rien");
    }

}
