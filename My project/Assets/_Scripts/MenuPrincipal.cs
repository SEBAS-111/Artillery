using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Menuinicial;

    public void iniciarjuego()
    {
        SceneManager.LoadScene(1);
    }

    public void finalizarjuego()
    {
        Application.Quit();
    }

    public void MostrarMenuinicio()
    {
        Menuinicial.SetActive(true);
    }
}
