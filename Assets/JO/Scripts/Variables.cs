using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Variables : MonoBehaviour
{   
    public static Variables managers{get;private set;}

    // Juancito
    public Vector3 position = new Vector3();
    public Dictionary<string, int> portales = new Dictionary<string, int>();
    public Dictionary<string, bool> diagInit = new Dictionary<string, bool>();

    // su vaina de muerto
    public bool malditoAmin = false;
    public bool todosMuertos = false;
    public ConversationSO dialogoTodosMuertos = null;
    public ConversationSO deadKernel = null;
    public ConversationSO deadElyiano = null;

    // Carlitos
    public string groupName;
    public bool boss;
    public int initial_mp = 10;
    public int initial_hp = 10;
    public int current_mp;
    public int current_hp;
    public List<string> puta;
    public int currentChallenge;
    public bool challengeCompleted;
    public string sceneName;
    public List<int> challengesCompletedElyiano;
    public List<int> challengesCompletedMagicant;
    public List<int> challengesCompletedLaPuta;
    public List<int> challengesCompletedKonohagakure;
    public List<int> challengesCompletedNeovice;
    public List<int> challengesCompletedKernel;
    public bool portalCrossing;

    // Quoka
    public int score = -1;
    public string username = "unow";
    // Start is called before the first frame update
    void Awake(){
    #region  Singleton
        if(managers != null && managers != this){
            Debug.LogWarning("Mira mamaguevo hay 2 variables");
            Destroy(gameObject);
        }
        managers = this;
    #endregion
    }

    void Start()
    {
        current_hp = initial_hp;
        current_mp = initial_mp;

        portales.Add("Elyiano",0);
        portales.Add("Magicant",0);
        portales.Add("LaPuta",0);
        portales.Add("Konohagakure",0);
        portales.Add("Neovice",0);
        portales.Add("Kernel",0);

        diagInit.Add("Elyiano", false);
        diagInit.Add("Magicant", false);
        diagInit.Add("LaPuta", false);
        diagInit.Add("Konohagakure", false);
        diagInit.Add("Neovice", false);
        diagInit.Add("Kernel", false);

        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
