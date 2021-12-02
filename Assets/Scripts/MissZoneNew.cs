using UnityEngine;

public class MissZoneNew : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball") {
            FindObjectOfType<GameManager>().MissNew();
        }
    }
}
