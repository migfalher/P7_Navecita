using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AroManager : MonoBehaviour
{
    // public components
    public Material matEspera;
    public Material matSiguiente;
    public Material matCruzado;
    public TMP_Text aroTMP;
    public GameObject monedaManager;
    public GameObject tiempoManager;

    // private components
    private List<GameObject> aroList = new List<GameObject>();
    private MonedaManager monedaScript;
    private TiempoManager tiempoScript;
    private int aroCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        monedaScript = monedaManager.GetComponent<MonedaManager>();
        tiempoScript = tiempoManager.GetComponent<TiempoManager>();

        for (int i = 1; i < 11; i++)
        {
            GameObject aro = GameObject.Find(string.Format("Aro ({0})", i));
            aro.GetComponent<Renderer>().material = matEspera;
            aro.GetComponent<Aro>().manager = this;
            aroList.Add(aro);
        }

        aroList[0].GetComponent<Renderer>().material = matSiguiente;

        aroCount = aroList.Count;
        aroTMP.text = aroCount.ToString("00");
    }

    // each individual 'aro' calls method 'updateAro' to update itself and the next 'aro'
    public void updateAro(int index)
    {
        GameObject aroActual = aroList[index - 1];
        GameObject aroSiguiente = (index < aroList.Count) ? aroList[index] : null;

        Debug.Log(index);

        Material mat = aroActual.GetComponent<Renderer>().sharedMaterial;
        if (mat == (matSiguiente)) {
            if (aroSiguiente != null) {
                aroSiguiente.GetComponent<Renderer>().material = matSiguiente;
                aroActual.GetComponent<Renderer>().material = matCruzado;
                aroCount--;
                aroTMP.text = aroCount.ToString("00");
            } else {
                StartCoroutine(LoadVictoryScene());
            }
        } else {
            Debug.Log("ORDEN INCORRECTO");
            StartCoroutine(LoadFailureScene());
        }
    }

    private IEnumerator LoadVictoryScene()
    {
        yield return new WaitForSeconds(2);
        Data.monedas = monedaScript.getMonedas();
        Data.segundos = tiempoScript.getTiempo();
        Data.victoria = true;
        SceneManager.LoadScene("Finish");
    }

    private IEnumerator LoadFailureScene()
    {
        yield return new WaitForSeconds(1);
        Data.monedas = 0;
        Data.segundos = 0;
        Data.victoria = false;
        SceneManager.LoadScene("Finish");
    }
}
