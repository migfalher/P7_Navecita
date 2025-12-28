using UnityEngine;

public class Aro : MonoBehaviour
{
    // public components
    public AroManager manager;

    // private components
    private int aroIndex;
    private GameObject player;
    private bool entered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string name = this.gameObject.name;
        int startIndex = name.IndexOf("(") + 1;
        int endIndex = name.IndexOf(")");
        int length = endIndex - startIndex;
        aroIndex = int.Parse(name.Substring(startIndex, length));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (entered == false)
        {
            entered = true;
            manager.updateAro(aroIndex);
        }
    }
}
