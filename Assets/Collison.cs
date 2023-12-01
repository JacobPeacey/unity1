using UnityEngine;

public class CollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Replace "YourTag" with the tag of the other GameObject
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}
