using System;
using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiempoManager : MonoBehaviour
{
    // public components
    public TMP_Text cronometro;
    public float tiempo = 60;

    // private components
    private int minutos = 0;
    private int segundos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadFailureScene());
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;

        minutos = Mathf.FloorToInt(tiempo / 60F);
        segundos = Mathf.FloorToInt(tiempo - (minutos * 60F));

        cronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    private IEnumerator LoadFailureScene()
    {
        yield return new WaitUntil(() => tiempo < 0);
        yield return new WaitForSeconds(0.1f);
        Data.monedas = 0;
        Data.segundos = 0;
        Data.victoria = false;
        SceneManager.LoadScene("Finish");
    }

    public int getTiempo () { return Mathf.FloorToInt(tiempo); }
}
