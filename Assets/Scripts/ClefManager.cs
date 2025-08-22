using UnityEngine;
using System;
using System.Collections.Generic;



public class ClefManager : MonoBehaviour
{
    
    public float baseY = 0f;
    public float stepY = 0.2f;

    public static string[] notes;


       

    public void Start()
    {

        // Récupération de la plage de notes en fonction de la clé choisie
        notes = new string[14];
        int position = 12;
        switch (Global.currentClef)
        {
            case Global.ClefType.CleFa: position = 0; break;
            case Global.ClefType.CleSol: position = 12; break;
            case Global.ClefType.CleUt3: position = 6; break;
        }
        Array.Copy(Global.toutesLesNotes, position, notes, 0, 14);

        // for (int i = 0; i < notes.Length; i++)
        // {
        //     print($"notes {i} = {notes[i]}");
        // }

        // Récupération de l'exercice en cours
        Global.exerciceEnCours = Global.exercice1;

        // Positionnement des boutons en fonction des notes comprises dans l'exercice
        placerBoutons();

    }


    private void placerBoutons()
    {
        // Compter combien on va avoir de bouton pour savoir où les placer
        int nbBoutons = Global.exerciceEnCours.Count;
    }

    public float GetNoteY(int index)
    {

        // int index = Array.IndexOf(notes, noteName);
        float positionY = indexVersPositionY(index);

        return positionY;

    }

    private float indexVersPositionY(int index)
    {
        float ecart = 0.30f;
        switch (index)
        {
            case 0 : return 0f-(ecart * 8);
            case 1 : return 0f-(ecart * 7);
            case 2 : return 0f-(ecart * 6);
            case 3 : return 0f-(ecart * 5);
            case 4 : return 0f-(ecart * 4);
            case 5 : return 0f-(ecart * 3);
            case 6 : return 0f-(ecart * 2);
            case 7 : return 0f-(ecart * 1);
            case 8 : return 0f ;
            case 9 : return 0f+(ecart * 1);
            case 10 : return 0f+(ecart * 2);
            case 11 : return 0f+(ecart * 3);
            case 12 : return 0f+(ecart * 4);
            case 13 : return 0f+(ecart * 5);
            default: return 60f;
        }
    }

 
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Global.currentClef = Global.ClefType.CleSol;
            print("Clé : Sol");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Global.currentClef = Global.ClefType.CleFa;
            print("Clé : Fa");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Global.currentClef = Global.ClefType.CleUt3;
            print("Clé : Ut3");
        }
    }
}
