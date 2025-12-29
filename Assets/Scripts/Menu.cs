using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnJugarPress()
    {
        StartCoroutine(wait("Game"));
    }

    public void OnSalirPress()
    {
        StartCoroutine(wait("0"));
    }

    public void OnMenuPress()
    {
        StartCoroutine(wait("Menu"));
    }

    private IEnumerator wait(string scene) {
        yield return new WaitForSeconds(0.4f);
        if (scene.Equals("0")) {
            Application.Quit();
        } else {
            SceneManager.LoadScene(scene);
        }
    }
}
