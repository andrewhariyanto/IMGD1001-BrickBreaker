using UnityEngine;
using UnityEngine.SceneManagement;

public class VersionNotes : MonoBehaviour
{
    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene("Menu");
        }
    }
}
