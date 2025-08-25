using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using Unity.Mathematics;



public class ClefManager : MonoBehaviour
{
    
    public float baseY = 0f;
    public float stepY = 0.2f;

    
    public Button boutonDo;
    public Button boutonRe;
    public Button boutonMi;
    public Button boutonFa;
    public Button boutonSol;
    public Button boutonLa;
    public Button boutonSi;

    public SpriteRenderer cleSol;
    public SpriteRenderer cleFa;
    public SpriteRenderer cleUt;


    public void Start()
    {

        // Récupération de la plage de notes en fonction de la clé choisie
        Global.notesCleEnCours = new string[14];
        int position = 12;
        switch (Global.currentClef)
        {
            case Global.ClefType.CleFa: { position = 0; cleFa.enabled = true; break; }
            case Global.ClefType.CleSol: { position = 12; cleSol.enabled = true; break; }
            case Global.ClefType.CleUt3: { } position = 6; cleUt.enabled = true; break;
        }
        Array.Copy(Global.toutesLesNotes, position, Global.notesCleEnCours, 0, 14);

        string stringnotes = string.Join(", ", Global.notesCleEnCours);
        print($"notes en cours = {stringnotes}");


        
    }


    public void placerBoutons()
    {
        reinitialiserPositionBoutons();
        // Compter combien on va avoir de bouton pour savoir où les placer
        int nbBoutons = Global.currentExercice.Count;

        // Largeur d'un bouton (on récupère juste le do, les autres sont identiques)
        RectTransform buttonRect = boutonDo.GetComponent<RectTransform>();
        float largeurBouton = buttonRect.rect.width;
  
        //  Espacement entre 2 boutons
        int espacement = 80;

        // Déterminer la position x de départ de la ligne de bouton
        float xDepart;
        if (nbBoutons % 2 == 0)
            xDepart = 0 - ((espacement + largeurBouton) / 2) - (espacement * (nbBoutons / 2 - 1)) - (largeurBouton * (nbBoutons / 2 - 1));
        else
            xDepart = 0 - (math.floor(nbBoutons / 2) * espacement) - (largeurBouton *  math.floor(nbBoutons /2) );

        //xDepart = -120;
        float xDiffDepartsSuivants = espacement + largeurBouton;

        List<string> notes = new List<string>();;
        for (int i = 0; i < Global.currentExercice.Count; i++)
        {
            string note = Global.notesCleEnCours[Global.currentExercice[i]];
            note = note.Substring(0, note.Length - 1);
            notes.Add(note);
        }   

        int index = 0;
        if (notes.Contains("Do"))
        {
            boutonDo.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }
        if (notes.Contains("Re"))
        {
            boutonRe.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }
        if (notes.Contains("Mi"))
        {
            boutonMi.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }
        if (notes.Contains("Fa"))
        {
            boutonFa.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }
        if (notes.Contains("Sol"))
        {
            boutonSol.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }
        if (notes.Contains("La"))
        {
            boutonLa.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }
        if (notes.Contains("Si"))
        {
            boutonSi.transform.localPosition = new Vector3(xDepart + xDiffDepartsSuivants * index, 0, 0);
            index++;
        }

    }

    private void reinitialiserPositionBoutons()
    {
        int y = -800;
        boutonDo.transform.localPosition = new Vector3(-750, y, 0);
        boutonRe.transform.localPosition = new Vector3(-620, y, 0);
        boutonMi.transform.localPosition = new Vector3(-490, y, 0);
        boutonFa.transform.localPosition = new Vector3(-360, y, 0);
        boutonSol.transform.localPosition = new Vector3(-230, y, 0);
        boutonLa.transform.localPosition = new Vector3(-100, y, 0);
        boutonSi.transform.localPosition = new Vector3(30 , y , 0);
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


}
