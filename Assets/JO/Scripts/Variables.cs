using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{   
    public static Variables managers{get;private set;}


    // Juancito
    public Vector3 position = new Vector3();
    public Dictionary<string, int> portales = new Dictionary<string, int>();


    // Carlitos
    public string groupName;
    public bool boss;
    public int mp;
    public int hp;
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

    // Quoka
    public int score = 1000;
    public string username = "Juan El egro";
    // Start is called before the first frame update
    void Awake(){
    #region  Singleton
        if(managers == null && managers != this){
            Debug.LogWarning("Mira mamaguevo hay 2 variables");
            Destroy(gameObject);
        }
        managers = this;
    #endregion
    }

    void Start()
    {
        
        portales.Add("Elyiano",0);
        portales.Add("Magicant",0);
        portales.Add("LaPuta",0);
        portales.Add("Konohagakure",0);
        portales.Add("Neovice",0);
        portales.Add("Kernel",0);
        
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
