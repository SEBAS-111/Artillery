using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PerderManager : MonoBehaviour
{

    public GameObject panelPerder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelPerder.SetActive(false);
    }

    public void MostrarPerder()
    {
        panelPerder.SetActive(true);
    }

    public void Reintentar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void salir()
    {
        Application.Quit();
    }
}
