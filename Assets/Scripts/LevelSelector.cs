using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void GoToLevel1() {
        SceneManager.LoadScene("NewLevel1");
    }

    public void GoToLevel2() {
        SceneManager.LoadScene("NewLevel2");
    }

    public void GoToLevel3() {
        SceneManager.LoadScene("NewLevel3");
    }
}
