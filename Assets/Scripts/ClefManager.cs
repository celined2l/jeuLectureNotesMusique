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
       

    public void Start()
    {

        // Récupération de la plage de notes en fonction de la clé choisie
        Global.notesCleEnCours = new string[14];
        int position = 12;
        switch (Global.currentClef)
        {
            case Global.ClefType.CleFa: position = 0; break;
            case Global.ClefType.CleSol: position = 12; break;
            case Global.ClefType.CleUt3: position = 6; break;
        }
        Array.Copy(Global.toutesLesNotes, position, Global.notesCleEnCours, 0, 14);

        // for (int i = 0; i < Global.notesCleEnCours.Length; i++)
        // {
        //     print($"notes {i} = {Global.notesCleEnCours[i]}");
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

        // Largeur d'un bouton (on récupère juste le do, les autres sont identiques)
        RectTransform buttonRect = boutonDo.GetComponent<RectTransform>();
        float largeurBouton = buttonRect.rect.width;
  
        //  Espacement entre 2 boutons
        int espacement = 20;

        // Déterminer la position x de départ de la ligne de bouton
        float xDepart;
        if (nbBoutons % 2 == 0)
            xDepart = 0 - ((espacement + largeurBouton) / 2) - (espacement * (nbBoutons / 2 - 1)) - (largeurBouton * (nbBoutons / 2 - 1));
        else
            xDepart = 0 - (math.floor(nbBoutons / 2) * espacement) - (largeurBouton *  math.floor(nbBoutons /2) );

        //xDepart = -120;
        float xDiffDepartsSuivants = espacement + largeurBouton;

        print("nbBoutons % 2  = " + nbBoutons % 2 ) ;
        print("xDepart = " + xDepart) ;
        print("nbBoutons " + nbBoutons);
        print("largeurBouton " + largeurBouton);
        

        List<string> notes = new List<string>();;
        for (int i = 0; i < Global.exerciceEnCours.Count; i++)
        {
            string note = Global.notesCleEnCours[Global.exerciceEnCours[i]];
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
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     Global.currentClef = Global.ClefType.CleSol;
        //     print("Clé : Sol");
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     Global.currentClef = Global.ClefType.CleFa;
        //     print("Clé : Fa");
        // }
        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     Global.currentClef = Global.ClefType.CleUt3;
        //     print("Clé : Ut3");
        // }
    }
}
