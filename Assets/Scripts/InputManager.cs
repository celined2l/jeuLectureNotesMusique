using UnityEngine;
using TMPro;

public class InputManager : MonoBehaviour
{
    public HitZone hitZone;
    public TempoManager tempoManager;
    public AudioSource feedbackAudio;
    public AudioClip correctSfx;
    public AudioClip missSfx;
    public TMP_Text scoreText;
    public TMP_Text niveauText;


    public GameObject feedbackPrefab;
    public Transform feedbackParent;

    private void Start()
    {
        UpdateScoreUI();
    }


    public void TryHit(string pressedNote)
    {
        print($"pressedNote : {pressedNote} - currentNoteName : {hitZone.currentNoteName}");

        var col = hitZone.currentNoteCollider;
        if (col == null)
        {
            Miss();
            return;
        }

        if (hitZone.currentNoteName != pressedNote)
        {
            Miss();
            return;
        }

        float centerX = hitZone.transform.position.x;
        float noteX = col.bounds.center.x;
        float dx = Mathf.Abs(noteX - centerX);

        if (dx <= hitZone.hitWindowHalfWidth)
        {
            int add = 1;
            //if (dx <= hitZone.hitWindowHalfWidth * perfectWindowFraction) add += perfectBonus;
            Global.score += add;
            UpdateScoreUI();
            ShowScoreFeedback(1);
            //if (feedbackAudio && correctSfx) feedbackAudio.PlayOneShot(correctSfx);
            GameObject.Destroy(col.gameObject);
            Global.compteurErreur = 0;
        }
        else { Miss(); }
    }

    public void Miss()
    {
        if (Global.score > 0)
        {
            Global.score -= 1;
            UpdateScoreUI();
            ShowScoreFeedback(-1);
            Global.compteurErreur++;
        }

        //if (feedbackAudio && missSfx) feedbackAudio.PlayOneShot(missSfx);
    }



    public void UpdateScoreUI()
    {
        scoreText.text = $"Score: {Global.score}";
        niveauText.text = $"Niveau: {Global.level +1}";
      

    }
    


    void ShowScoreFeedback(int value)
    {
        GameObject go = Instantiate(feedbackPrefab, feedbackParent);

        // Position au centre ou personnalisée
        go.transform.localPosition = new Vector2(230, -130);

        var feedback = go.GetComponent<ScoreFeedback>();
        feedback.Init(
            (value > 0 ? "+" : "") + value.ToString(),
            value > 0 ? Color.green : Color.red
        );
    }
}
