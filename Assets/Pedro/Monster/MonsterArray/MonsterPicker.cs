using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPicker : MonoBehaviour
{
    public static MonsterPicker Picker { get; private set; }

    private List<MonsterSO> monstersElyiano = null;
    private List<MonsterSO> monstersMagicant = null;
    private List<MonsterSO> monstersLaPuta = null;
    private List<MonsterSO> monstersKonohagakure = null;
    private List<MonsterSO> monstersNeovice = null;

    private void Awake()
    {
        #region  Singleton
        if (Picker != null && Picker != this)
        {
            Debug.LogWarning("Pickers duplicados.");
            Destroy(gameObject);
        }
        Picker = this;
        #endregion    
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
        if (monstersElyiano == null) Debug.LogError("Monsters Elyano nulos", this);
        else if(monstersElyiano.Count == 0) Debug.LogError("Monsters Elyano vacio", this);

        if (monstersMagicant == null) Debug.LogError("Monsters Magicant nulos", this);
        else if (monstersMagicant.Count == 0) Debug.LogError("Monsters Magicant vacio", this);

        if (monstersLaPuta == null) Debug.LogError("Monsters LaPuta nulos", this);
        else if (monstersLaPuta.Count == 0) Debug.LogError("Monsters LaPuta vacio", this);

        if (monstersKonohagakure == null) Debug.LogError("Monsters Konohagakure nulos", this);
        else if (monstersKonohagakure.Count == 0) Debug.LogError("Monsters Konohagakure vacio", this);

        if (monstersNeovice == null) Debug.LogError("Monsters Neovice nulos", this);
        else if (monstersNeovice.Count == 0) Debug.LogError("Monsters Neovice vacio", this);
#endif
    }

    public MonsterSO GetMonster(int monsterInd)
    {
        string scene = Variables.managers.sceneName;

        switch (scene.Trim())
        {
            case "Elyano":
                return monstersElyiano[monsterInd];
            case "Magicant":
                return monstersMagicant[monsterInd];
            case "LaPuta":
                return monstersLaPuta[monsterInd];
            case "Konohagakure":
                return monstersKonohagakure[monsterInd];
            case "Neovice":
                return monstersNeovice[monsterInd];
            default:
                return null;
        }
    }

    public void RemoveMonster(int monsterInd)
    {
        string scene = Variables.managers.sceneName;

        switch (scene.Trim())
        {
            case "Elyano":
                monstersElyiano.RemoveAt(monsterInd);
                return;
            case "Magicant":
                monstersMagicant.RemoveAt(monsterInd);
                return;
            case "LaPuta":
                monstersLaPuta.RemoveAt(monsterInd);
                return;
            case "Konohagakure":
                monstersKonohagakure.RemoveAt(monsterInd);
                return;
            case "Neovice":
                monstersNeovice.RemoveAt(monsterInd);
                return;
            default:
                Debug.LogWarning("Epa, chequea el nombre de la escena que me pasaste :(", this);
                return;
        }
    }
}
