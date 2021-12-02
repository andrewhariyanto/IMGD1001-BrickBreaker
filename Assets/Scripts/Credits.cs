using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void BackToStart()
    {
        if (Input.GetKey(KeyCode.Escape)) {
            Debug.Log("here");
            SceneManager.LoadScene("Menu");
        }
        //SceneManager.LoadScene("Menu");
    }
}
