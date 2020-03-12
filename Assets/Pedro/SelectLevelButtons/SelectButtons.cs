using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectButtons : MonoBehaviour
{
    public static SelectButtons Manager { get; private set; }
    public Button butMagicant = null;
    public Button butLaPuta = null;
    public Button butKono = null;
    // public Button butNeo = null;

    private void Awake()
    {
        #region  Singleton
        if (Manager != null && Manager != this)
        {
            Debug.LogWarning("SelectButtons duplicados.");
            Destroy(gameObject);
        }
        Manager = this;
        #endregion
    }

    private void Start()
    {
        if (butMagicant == null) Debug.LogWarning("Mira maldito, el boton de Magicant no esta");
        else butMagicant.gameObject.SetActive(false);

        if (butLaPuta == null) Debug.LogWarning("Mira maldito, el boton de LaPuta no esta");
        else butLaPuta.gameObject.SetActive(false);

        if (butKono == null) Debug.LogWarning("Mira maldito, el boton de Kono no esta");
        else butKono.gameObject.SetActive(false);

        // if (butNeo == null) Debug.LogWarning("Mira maldito, el boton de Neo no esta");
        // else butNeo.gameObject.SetActive(false);

        DisableButtons();
    }

    public void ActivateButtons()
    {
        //if (Variables.managers.puta.Count >= 4) return;
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

    public void DisableButtons()
    {
        butMagicant.gameObject.SetActive(false);
        butLaPuta.gameObject.SetActive(false);
        butKono.gameObject.SetActive(false);
    }

    public void LoadMagicant()
    {
        Variables.managers.portales["Magicant"] = 1;
        DisableButtons();
    }
    public void LoadLaPuta()
    {
        Variables.managers.portales["LaPuta"] = 1;
        DisableButtons();
    }
    public void LoadKono()
    {
        Variables.managers.portales["Konohagakure"] = 1;
        DisableButtons();
    }
}
