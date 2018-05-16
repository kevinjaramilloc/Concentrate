using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public static Menu StaticTimer;
    [Header("Tiempo de juego")]
    public Text timeText;
    public float time;
    [Header("Image")]
    public GameObject win;
    public GameObject loser;
    [Header("Buttons")]
    public GameObject restart;
    public GameObject exit;
    public GameObject nextLevel;

    private void Start()
    {
        StaticTimer = GetComponent<Menu>();
    }

    public void Update ()
    {
        TimeGame();
        WinMode();
    }

    public void TimeGame()
    {
        //Ejecuta el tiempo de juego
        if (ModelPrefab.countWin < ModelPrefab.numerCubos)
        {
            time = time - 1 * Time.deltaTime;
            timeText.text = "Time : " + time.ToString("0");
        }

        if (time <= 0 && ModelPrefab.countWin<ModelPrefab.numerCubos)
        {
            //Si el tiempo es igual a cero, aparecen las imagenes y los botones
            timeText.text = null;
            loser.SetActive(true);
            restart.SetActive(true);
            exit.SetActive(true);
        }

    }

    public void WinMode()
    {
        //Activa el panel si el jugador gana
        if (ModelPrefab.countWin == ModelPrefab.numerCubos)
        {
            win.SetActive(true);
            restart.SetActive(true);
            exit.SetActive(true);
            nextLevel.SetActive(true);
        }
    }

}

