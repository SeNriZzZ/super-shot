using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _coinPickUpSound;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PlayerController player = other.GetComponent<PlayerController>();
                player.hasCoin = true;
                AudioSource.PlayClipAtPoint(_coinPickUpSound, transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }
}