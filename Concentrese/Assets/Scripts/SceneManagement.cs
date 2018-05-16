using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [Header("Music")]
    public AudioSource ambientSound;

    private void Start()
    {
        ambientSound.Play();
    }

    public void FirstScene()
    {
        //Realiza el cambio al primer nivel
            SceneManager.LoadScene("FirstScene");
    }

    public void SecondScene()
    {
        //Realiza el cambio al segundo nivel
            SceneManager.LoadScene("SecondScene");
    }

    public void FinalScene()
    {
        //Realiza el cambio al último nivel
            SceneManager.LoadScene("FinalScene");
    }

    public void UserInterfaceScene()
    {
        //Lo devuelve al menu principal
        SceneManager.LoadScene("SceneUI");
    }
}
