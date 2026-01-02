using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    public GameObject menuPausa;

    public void MostratmenuPausa()
    {
        menuPausa.SetActive(true);
    }

    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
    }

    public void RegresarPantalla()
    {
        SceneManager.LoadScene(0);
    }

}
