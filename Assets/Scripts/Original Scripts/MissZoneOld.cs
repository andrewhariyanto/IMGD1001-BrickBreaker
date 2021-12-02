using UnityEngine;

public class MissZoneOld : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball") {
            FindObjectOfType<GameManager>().MissOri();
        }
    }
}
