using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class NoteSpawner : MonoBehaviour
{
    public TempoManager tempo;
    public InputManager inputManager;
    public GameObject notePrefab;
    // public Transform spawnPoint;
    public Transform hitZone;
    //private string[] notes = new string[] { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" };
    // public string[] notes = new string[14] ;
          
    [Header("Rythme")]
    public int beatsAhead = 4;      // nb de battements d’avance
    public int spawnEvery = 1;      // une note tous les X battements

    [Header("Défilement visuel")]
    public float noteSpeed = 5f;    // unités par seconde (contrôle visuel de la vitesse)


    private void Start()
    {
        //if (tempoManager == null) tempoManager = FindObjectOfType<TempoManager>();
        //StartCoroutine(SpawnRoutine());
    }



    void OnEnable()
    {
        TempoManager.OnBeat += HandleBeat;
    }

    void OnDisable()
    {
        TempoManager.OnBeat -= HandleBeat;
    }

    private void HandleBeat(int beatCount)
    {
        if (beatCount % spawnEvery == 0) // ex: tous les temps ou toutes les 2 mesures
        {
            SpawnNote();
        }
    }

    public void SpawnNote()
    {
        // Tirage de la note dans la liste de celles comprises dans l'exercice
        int index = Random.Range(0, Global.exercice1.Count);

        string noteName = ClefManager.notes[Global.exercice1[index]];

        // Calcul du Y selon la clé
        ClefManager clefManager = FindObjectsByType<ClefManager>(FindObjectsSortMode.None)[0];
        float y = clefManager.GetNoteY(Global.exercice1[index]);

        // Spawn à droite du hitZone pour que la note arrive pile au battement
        float distance = noteSpeed * (beatsAhead * tempo.secPerBeat);
        float spawnX = hitZone.position.x + distance;
        // j'y arrive pas de toute façon... alors on bouge pas le x
        //float spawnX = 12f;

        // Instantiation
        GameObject note = Instantiate(notePrefab, new Vector3(spawnX, y, hitZone.position.z), Quaternion.identity);

        var mover = note.GetComponent<NoteController>();
        if (mover == null) mover = note.AddComponent<NoteController>();
        mover.Init(spawnX, y, hitZone.position.z, noteSpeed, beatsAhead, tempo.secPerBeat);
        mover.noteName = noteName;
        mover.inputManager = this.inputManager;

//        print($"Global.score = {Global.score}");

    }

}
