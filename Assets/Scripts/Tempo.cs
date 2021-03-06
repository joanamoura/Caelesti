using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Tempo : MonoBehaviour
{

    [SerializeField]
    private Text texto;
    float timeLeft = 20.0f;
	//teste;
    void Update()
    {

        texto.text = "Tempo restante: " + Mathf.CeilToInt(timeLeft).ToString();

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {

        Invoke("mudarCena", 0.1f);
    }

    void mudarCena()
    {
        SceneManager.LoadScene("Historia pt2");
    }
}
