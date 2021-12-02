using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsToStart : MonoBehaviour
{

    public void LoadCredits()
    {
        SceneManager.LoadScene("Menu");
    }
}
