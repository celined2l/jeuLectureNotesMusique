using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitZone : MonoBehaviour
{
    public float hitWindowHalfWidth = 2f;
    private bool drawGizmo = true;
    public Collider2D currentNoteCollider;
    public string currentNoteName;

    public AudioClip metronomeClick; 
    private AudioSource audioSource;

    public InputManager inputManager;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Reset() { var col = GetComponent<Collider2D>(); col.isTrigger = true; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            audioSource.clip = metronomeClick;
            audioSource.PlayOneShot(metronomeClick);

            currentNoteCollider = other;
            var nc = other.GetComponent<NoteController>();
            currentNoteName = nc != null ? nc.noteName.Substring(0, nc.noteName.Length - 1) : string.Empty;

//            print("currentNoteName : " + currentNoteName);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other == currentNoteCollider)
        {
            currentNoteCollider = null;
            currentNoteName = null;
            //inputManager.Miss();
        }
    }

    public bool IsInTimingWindow(Collider2D noteCol)
    {
        if (noteCol == null) return false;
        float centerX = transform.position.x;
        float noteX = noteCol.bounds.center.x;
        return Mathf.Abs(noteX - centerX) <= hitWindowHalfWidth;
    }

    private void OnDrawGizmos()
    {
        if (!drawGizmo) return;
        Gizmos.color = Color.green;
        Vector3 c = transform.position;
        Gizmos.DrawLine(new Vector3(c.x - hitWindowHalfWidth, c.y - 5f, 0f), new Vector3(c.x - hitWindowHalfWidth, c.y + 5f, 0f));
        Gizmos.DrawLine(new Vector3(c.x + hitWindowHalfWidth, c.y - 5f, 0f), new Vector3(c.x + hitWindowHalfWidth, c.y + 5f, 0f));
        Gizmos.color = Color.white;
        Gizmos.DrawLine(new Vector3(c.x, c.y - 5f, 0f), new Vector3(c.x, c.y + 5f, 0f));
    }
}
