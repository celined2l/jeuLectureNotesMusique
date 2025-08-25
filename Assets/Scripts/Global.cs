using UnityEngine;
using System.Collections.Generic;
using NUnit.Framework;


public static class Global
{

    // Gestion des clés
    public enum ClefType { CleSol, CleFa, CleUt3 } 
    public static ClefType currentClef = ClefType.CleSol;

    // Tempo
    public static float bpm = 50f;

    public static bool pause = false;

    // position Y où on décide de détruire la note car elle n'est plus utile
    public static float despawnY = -5f;

    // position X où on décide que c'est raté 
    public static float rateX = -1f;


    // Gestion du score
    public static int score;
    public static int perfectBonus = 2;
    public static float perfectWindowFraction = 0.25f;

    // Gestion du mode d'exercice
    public enum ModeExercice { ligne, interligne, mixte }
    public static ModeExercice currentModeExercice = ModeExercice.ligne ;

    // Gestion des exercices de notes
    //private string[] notes = new string[] { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" };
    public static string[] toutesLesNotes = new string[] { "Mi1", "Fa1", "Sol1", "La1", "Si1",
                                                    "Do2", "Re2", "Mi2", "Fa2", "Sol2", "La2", "Si2",
                                                    "Do3", "Re3", "Mi3", "Fa3", "Sol3", "La3", "Si3",
                                                    "Do4", "Re4", "Mi4", "Fa4", "Sol4", "La4", "Si4" };

    public static string[] notesCleEnCours;


    // Liste des index des notes concerné
     public static List<int> exerciceToutes = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

    public static List<int> currentExercice;
    public static int level = 0;
    public static int seuilLevel = 5;

    // Exercices sur les lignes
    public static List<int> exercice1 = new List<int>() { 2, 4, 6 };
    public static List<int> exercice2 = new List<int>() { 2, 4, 6, 8 };
    public static List<int> exercice3 = new List<int>() { 2, 4, 6, 8, 10 };
    public static List<int> exercice4 = new List<int>() { 0, 2, 4, 6, 8, 10 };
    public static List<int> exercice5 = new List<int>() { 2, 4, 6, 8, 10, 12};
    public static List<int> exercice6 = new List<int>() {0, 2, 4, 6, 8, 10, 12 };

    // Exercices sur les inerlignes
    public static List<int> exercice7 = new List<int>() { 3, 5, 7};
    public static List<int> exercice8 = new List<int>() { 3, 5, 7, 9 };
    public static List<int> exercice9 = new List<int>() { 1, 3, 5, 7, 9 };
    public static List<int> exercice10 = new List<int>() { 3, 5, 7, 9, 11 };
    public static List<int> exercice11 = new List<int>() { 1, 3, 5, 7, 9, 11};
    
    // Exercices mixtes
    public static List<int> exercice12 = new List<int>() { 2, 3, 4, 5, 6, 7 };
    public static List<int> exercice13 = new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9 };
    public static List<int> exercice14 = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };


    public static List<List<int>> exercicesLigne = new List<List<int>> { exercice1, exercice2, exercice3, exercice4, exercice5, exercice6 };
    public static List<List<int>> exercicesInterLigne = new List<List<int>> { exercice7, exercice8, exercice9, exercice10, exercice11 };
    public static List <List <int> > exercicesMixte = new List<List <int> > {exercice12, exercice13, exercice14, exerciceToutes };

  
 
}
