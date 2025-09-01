using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TempoManager : MonoBehaviour
{
    
    public AudioClip metronomeClick;        
    public AudioClip accentClip;      
    private AudioSource audioSource;

    public float songPosition;        
    public float songPositionInBeats; 
    public float secPerBeat;

    public Text bpmLabel;

    public GameObject boutonPause;
    public Image imagePause;
    public Image imageLecture;

    private double dspSongTime;
    private double nextTickDspTime;
    private int beatCount = 0;

    public static event Action<int> OnBeat; // int = numéro du battement

    private const double startDelay = 1.0f; // délai avant le début


    void Start()
    {
        secPerBeat = 60f / Global.bpm;
        dspSongTime = (float)AudioSettings.dspTime;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.playOnAwake = false;
        nextTickDspTime = dspSongTime + secPerBeat + startDelay ;
    }


    public void SetTempo(float newBpm)
    {
        Global.bpm = newBpm;
        secPerBeat = 60f / Global.bpm;
        nextTickDspTime = AudioSettings.dspTime + secPerBeat;
        UpdateLabel();
    }

    private void UpdateLabel()
    {
        bpmLabel.text = $"BPM: {Mathf.RoundToInt(Global.bpm)}";
    }

    private void Update()
    {
        // calcul du temps musical basé sur l'horloge audio
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;

        if (AudioSettings.dspTime >= nextTickDspTime - 0.001f)
        {
            //PlayScheduledTick(nextTickDspTime);

            // 🔔 Appeler l’événement
            OnBeat?.Invoke(beatCount);

            beatCount++;
            nextTickDspTime += secPerBeat;
        }
    }

    public void Pause(string donnee)
    {
        if (Global.pause)
        {
            Global.pause = false;
            Time.timeScale = 1f;
            AudioListener.pause = false;
            //changement de l'image
            imagePause.enabled = true;
            imageLecture.enabled = false;
        }
        else
        {
            Global.pause = true;
            Time.timeScale = 0f;
            AudioListener.pause = true;
            imagePause.enabled = false;
            imageLecture.enabled = true;
        }
    }

    public void RetourMenu(String donnee)
    {
        SceneManager.LoadScene("MenuScene");
    }

    void PlayScheduledTick(double dspTime)
    {
        // if (accentClip != null && beatCount % 4 == 0)
        // {
        //     audioSource.clip = accentClip;
        //     audioSource.PlayScheduled(dspTime);
        // }
        //else
        if (metronomeClick != null)
        {
            audioSource.clip = metronomeClick;
            audioSource.PlayScheduled(dspTime);
        }
    }

}
