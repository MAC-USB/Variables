using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{   

    // Juancito
    public Vector3 position = new Vector3();
    public Dictionary<string, int> portales = new Dictionary<string, int>();


    // Carlitos
    public int currentChallenge;
    public bool challengeCompleted;
    public string sceneName;
    public List<int> challengesCompletedElyiano;
    public List<int> challengesCompletedMagicant;
    public List<int> challengesCompletedLaPuta;
    public List<int> challengesCompletedKonohagakure;
    public List<int> challengesCompletedNeovice;
    public List<int> challengesCompletedKernel;
    
    // Start is called before the first frame update
    void Start()
    {
        portales.Add("Elyiano",0);
        portales.Add("Magicant",0);
        portales.Add("LaPuta",0);
        portales.Add("Konohagakure",0);
        portales.Add("Neovice",0);
        portales.Add("Kernel",0);
        
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
