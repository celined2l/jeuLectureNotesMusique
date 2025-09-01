using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using NUnit.Framework;
using Unity.VisualScripting;


public class NoteSpawner : MonoBehaviour
{
    public TempoManager tempo;
    public InputManager inputManager;
    public GameObject notePrefab;
    public GameObject notePrefabBarre;
    public GameObject notePrefabDessus;
    // public Transform spawnPoint;
    public Transform hitZone;

    public ClefManager clefManager;


    [Header("Rythme")]
    public int beatsAhead = 4;      // nb de battements d’avance
    public int spawnEvery = 1;      // une note tous les X battements

    [Header("Défilement visuel")]
    public float noteSpeed = 5f;    // unités par seconde (contrôle visuel de la vitesse)




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
        // Gérer le changement d'exercice
        gestionChangementExercice();

        // Tirage de la note dans la liste de celles comprises dans l'exercice
        int index = UnityEngine.Random.Range(0, Global.currentExercice.Count);

        print("index = " + index);
        string noteName = Global.notesCleEnCours[Global.currentExercice[index]];

        // Calcul du Y selon la clé
        //ClefManager clefManager = FindObjectsByType<ClefManager>(FindObjectsSortMode.None)[0];
        float y = clefManager.GetNoteY(Global.currentExercice[index]);

        // Spawn à droite du hitZone pour que la note arrive pile au battement
        // float distance = noteSpeed * (beatsAhead * tempo.secPerBeat);
        // float spawnX = hitZone.position.x + distance;

        float spawnX = 10;

        // j'y arrive pas de toute façon... alors on bouge pas le x
        //float spawnX = 12f;

        // Instantiation
        GameObject note;
        // if (noteName == "Do")
        //     note = Instantiate(notePrefabBarre, new Vector3(spawnX, y, hitZone.position.z), Quaternion.identity);
        // else
        note = Instantiate(notePrefab, new Vector3(spawnX, y, hitZone.position.z), Quaternion.identity);

        var mover = note.GetComponent<NoteController>();
        if (mover == null) mover = note.AddComponent<NoteController>();
        mover.Init(spawnX, y, hitZone.position.z, noteSpeed, beatsAhead, tempo.secPerBeat);
        mover.noteName = noteName;
        mover.inputManager = this.inputManager;

        //print($"Global.score / level = {Global.score} / level {Global.level}");
   


    }

    private void gestionChangementExercice()
    {
        // cas du début, initialisation
        if (Global.currentExercice == null)
        {
            if (Global.currentModeExercice == Global.ModeExercice.ligne)
                Global.currentExercice = Global.exercicesLigne[0];
            else if (Global.currentModeExercice == Global.ModeExercice.interligne)
                Global.currentExercice = Global.exercicesInterLigne[0];
            else if (Global.currentModeExercice == Global.ModeExercice.mixte)
                Global.currentExercice = Global.exercicesMixte[0];
            // clefManager.placerBoutons();
        }

        // Ensuite on change de niveau en fonction du score
        int niveauTheorique = (int)math.floor(Global.score / Global.seuilLevel);

        bool changerNiveau = false;
        if (niveauTheorique != Global.level)
            changerNiveau = true;

        

        if (changerNiveau)
        {

            

            int nbNiveauxMaxPourModeExercice = 0;
            if (Global.currentModeExercice == Global.ModeExercice.ligne)
                nbNiveauxMaxPourModeExercice = Global.exercicesLigne.Count;
            else if (Global.currentModeExercice == Global.ModeExercice.interligne)
                nbNiveauxMaxPourModeExercice = Global.exercicesInterLigne.Count;
            else if (Global.currentModeExercice == Global.ModeExercice.mixte)
                nbNiveauxMaxPourModeExercice = Global.exercicesMixte.Count;

            ChangerNiveau(niveauTheorique, nbNiveauxMaxPourModeExercice);
        }
        

        string exo = string.Join(", ", Global.currentExercice);
        print($" score / level / niveauTheorique = {Global.score} /  {Global.level} / {niveauTheorique} ({exo})");

    }

    private void ChangerNiveau(int niveauTheorique, int nbNiveauxMaxPourModeExercice)
    {
        bool monter = false;

        if (niveauTheorique > Global.level)
            monter = true;

        // Ajustement du niveau
        if (niveauTheorique != Global.level)
            Global.level = niveauTheorique;

        // changement d'exercice ou augmentation du tempo si pas d'autres exos dispos
        if (niveauTheorique > nbNiveauxMaxPourModeExercice && monter)
            Global.bpm += 10;
        else if (niveauTheorique > nbNiveauxMaxPourModeExercice && monter)
            Global.bpm -= 10;
        else if (Global.currentModeExercice == Global.ModeExercice.ligne)
            Global.currentExercice = Global.exercicesLigne[niveauTheorique];
        else if (Global.currentModeExercice == Global.ModeExercice.interligne)
            Global.currentExercice = Global.exercicesInterLigne[niveauTheorique];
        else if (Global.currentModeExercice == Global.ModeExercice.mixte)
            Global.currentExercice = Global.exercicesMixte[niveauTheorique];


        // Détruire les notes de l'exercice précédent
        detruireNotes();

            
    }


    private void detruireNotes()
    {
        GameObject[] notes = GameObject.FindGameObjectsWithTag("Note");

        foreach (GameObject go in notes)
        {
            Destroy(go);
        }
    }

}
