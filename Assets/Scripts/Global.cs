using UnityEngine;


public static class Global
{


    // Tempo
    public static float bpm = 50f;

    // Y où on décide de détruire la note car elle n'est plus utile
    public static float despawnY = -5f;

    // X où on décide que c'est raté 
    public static float rateX = -1f;


    // Gestion du score
    public static int score;
    public static int perfectBonus = 2;
    public static float perfectWindowFraction = 0.25f;


    // Gestion des exercices de notes
    //private string[] notes = new string[] { "Do", "Re", "Mi", "Fa", "Sol", "La", "Si" };
    public static string[] toutesLesNotes = new string[] { "Mi1", "Fa1", "Sol1", "La1", "Si1",
                                                    "Do2", "Re2", "Mi2", "Fa2", "Sol2", "La2", "Si2",
                                                    "Do3", "Re3", "Mi3", "Fa3", "Sol3", "La3", "Si3",
                                                    "Do4", "Re4", "Mi4", "Fa4", "Sol4", "La4", "Si4" };
    


    // public string[] exo_1_sol = new string[] { "Mi", "Sol", "Si" };
    // public string[] exo_1_ut = new string[] { "Fa", "La", "Do" };
    // public string[] exo_1_fa = new string[] { "Sol", "Mi", "La" };
    
    // public string[] exo_ 1_sol = new string[] { "Mi", "Sol", "Si" };
    // public string[] exo_1_ut = new string[] { "Fa", "La", "Do" };
    // public string[] exo_1_fa = new string[] { "Sol", "Mi", "La"};

    
}
