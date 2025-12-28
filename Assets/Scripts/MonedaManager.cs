using System.Collections.Generic;
using UnityEngine;

public class MonedaManager : MonoBehaviour
{
    // GameObject to instantiate
    public GameObject moneda;

    // private components
    private List<GameObject> spawnList = new List<GameObject>();
    private List<int> positionsList = new List<int>();
    private int monedaCount = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneda.GetComponent<Moneda>().manager = this;

        for (int i = 1; i <= 40; i++)
        {
            GameObject spawn = GameObject.Find(string.Format("Spawn ({0})", i));
            spawnList.Add(spawn);
        }

        for (int i = 0; i < 15; i++)
        {
            int rand = 0;
            do {rand = Random.Range(1, 26);} while (positionsList.Contains(rand));
            positionsList.Add(rand);
        }

        for (int i = 0; i < 5; i++)
        {
            int rand = 0;
            do { rand = Random.Range(26, 41); } while (positionsList.Contains(rand));
            positionsList.Add(rand);
        }

        foreach (int index in positionsList)
        {
            Vector3 pos = spawnList[index - 1].transform.position;
            Quaternion rot = moneda.transform.rotation;
            Instantiate(moneda, pos, rot);
        }
    }

    public void sumUpMonedaCount()
    {
        monedaCount++;
    }
}
