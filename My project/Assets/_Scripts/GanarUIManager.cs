using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GanarUIManager : MonoBehaviour
{

    public GameObject panelVictoria;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelVictoria.SetActive(false);
    }

    public void MostrarVictoria()
    {
        panelVictoria.SetActive(true);
    }

    public void SiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Salir()
    {
        Application.Quit();
    }

}
