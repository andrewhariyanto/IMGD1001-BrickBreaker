using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private void Update() {
        if (Input.GetKey(KeyCode.Return)) {
            SceneManager.LoadScene("Menu");
        }
    }
}
