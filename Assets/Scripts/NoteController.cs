using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class NoteController : MonoBehaviour
{
    [Tooltip("Note name, e.g., Do, Re, Mi, Fa, Sol, La, Si")]
    public string noteName = "Do";

    [Tooltip("Attribué par le spwaner ; Conductor caché pour les mises à jour de vitesse.")]
    public TempoManager tempoManager;

    public InputManager inputManager;

    private float y;
    private float z;
    private float startX;
    private float noteSpeed; // unités/sec
    private double spawnDSPTime;
    private double hitDSPTime;
    private bool vivante = true ;


    public void Init(float startX, float y, float z, float noteSpeed, double beatsAhead, float secPerBeat)
    {
        this.startX = startX;
        this.y = y;
        this.z = z;
        this.noteSpeed = noteSpeed;

        spawnDSPTime = AudioSettings.dspTime;
        hitDSPTime = spawnDSPTime + beatsAhead * secPerBeat;

        transform.position = new Vector3(startX, y, z);
    }

    private void Reset()
    {
        print("coucou reset");
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
        gameObject.tag = "Note";
    }

    // Retourne vrai si la note est sur le battement (optionnel)
    public bool IsOnBeat(double tolerance = 0.05)
    {
        double diff = AudioSettings.dspTime - hitDSPTime;
        return Mathf.Abs((float)diff) < tolerance;
    }


    void Update()
    {
        if (!Global.pause)
        {
            double elapsed = AudioSettings.dspTime - spawnDSPTime;
            float x = startX - noteSpeed * (float)elapsed; // défilement droite → gauche

            transform.position = new Vector3(x, transform.position.y, transform.position.z);

            // Baisse du score quand la note est sortie de la hitzone
            if (transform.position.x < Global.rateX && vivante)
            {
                vivante = false;
                inputManager.Miss();

                // Activer la gravité
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.gravityScale = 1;
            }


            // Destruction de la note lorsqu'elle est partie ailleurs
            if (transform.position.y < Global.despawnY) { Destroy(gameObject); }
        }
    }

   
}
