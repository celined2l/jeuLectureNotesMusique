using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public HitZone hitZone;
    public TempoManager tempoManager;
    public AudioSource feedbackAudio;
    public AudioClip correctSfx;
    public AudioClip missSfx;
    public TMP_Text scoreText;
        

    private void Start()
    {
        UpdateScoreUI();
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.A)) TryHit("Do");
    //     if (Input.GetKeyDown(KeyCode.S)) TryHit("Re");
    //     if (Input.GetKeyDown(KeyCode.D)) TryHit("Mi");
    //     if (Input.GetKeyDown(KeyCode.F)) TryHit("Fa");
    //     if (Input.GetKeyDown(KeyCode.G)) TryHit("Sol");
    //     if (Input.GetKeyDown(KeyCode.H)) TryHit("La");
    //     if (Input.GetKeyDown(KeyCode.J)) TryHit("Si");
    // }

    public void TryHit(string pressedNote)
    {
        //print($"pressedNote : {pressedNote} - currentNoteName : {hitZone.currentNoteName}");

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
            if (feedbackAudio && correctSfx) feedbackAudio.PlayOneShot(correctSfx);
            GameObject.Destroy(col.gameObject);
        }
        else { Miss(); }
    }

    public void Miss()
    {
        if (Global.score > 0)
        {
            Global.score -= 1;
            UpdateScoreUI();
        }    
        
        if (feedbackAudio && missSfx) feedbackAudio.PlayOneShot(missSfx);
    }

    private void UpdateScoreUI()
    {
        scoreText.text = $"Score: {Global.score}";
    }
}
