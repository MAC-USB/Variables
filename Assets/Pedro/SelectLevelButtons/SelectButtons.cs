using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButtons : MonoBehaviour
{
    public Button butMagicant = null;
    public Button butLaPuta = null;
    public Button butKono = null;
    public Button butNeo = null;

    private void Start()
    {
        if (butMagicant == null) Debug.LogWarning("Mira maldito, el boton de Magicant no esta");
        else butMagicant.gameObject.SetActive(false);

        if (butLaPuta == null) Debug.LogWarning("Mira maldito, el boton de LaPuta no esta");
        else butLaPuta.gameObject.SetActive(false);

        if (butKono == null) Debug.LogWarning("Mira maldito, el boton de Kono no esta");
        else butKono.gameObject.SetActive(false);

        if (butNeo == null) Debug.LogWarning("Mira maldito, el boton de Neo no esta");
        else butNeo.gameObject.SetActive(false);

        ActivateButtons();
    }

    public void ActivateButtons()
    {
        // Si has derrotado los de 4
        if (Variables.managers.puta.Count == 4)
        {
            butNeo.gameObject.SetActive(true);
            butMagicant.gameObject.SetActive(false);
            butLaPuta.gameObject.SetActive(false);
            butKono.gameObject.SetActive(false);
        }
        else
        {
            butNeo.gameObject.SetActive(false);
            butMagicant.gameObject.SetActive(true);
            butLaPuta.gameObject.SetActive(true);
            butKono.gameObject.SetActive(true);
            foreach (string boss in Variables.managers.puta)
            {
                switch (boss)
                {
                    case "Magicant":
                        butMagicant.gameObject.SetActive(false);
                        break;
                    case "LaPuta":
                        butLaPuta.gameObject.SetActive(false);
                        break;
                    case "Konohagakure":
                        butKono.gameObject.SetActive(false);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    public void DisableButtons()
    {
        butNeo.gameObject.SetActive(false);
        butMagicant.gameObject.SetActive(false);
        butLaPuta.gameObject.SetActive(false);
        butKono.gameObject.SetActive(false);
    }

    public void LoadMagicant() => SceneManager.LoadScene("Magicant");
    public void LoadLaPuta() => SceneManager.LoadScene("LaPuta");
    public void LoadKono() => SceneManager.LoadScene("Konohagakure");
    public void LoadNeo() => SceneManager.LoadScene("Neovice");
}
