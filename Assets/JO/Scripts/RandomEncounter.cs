using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class RandomEncounter : MonoBehaviour
{
    Scene currentScene;
    Variables variables;
    Vector3 prevPos;
    public List<int> challenges = null;
    List<int> completedChallenges = new List<int>();
    int currentChallenge;
    bool kernel;

    public ConversationSO preguntaAbrir = null;

    // Start is called before the first frame update
    void Start()
    {

        if (Variables.managers.portalCrossing){
            StartCoroutine(SimpleBlit.managers.FadeIn(TransType.Portal));
            Variables.managers.portalCrossing = false;
        }
        else{
            StartCoroutine(SimpleBlit.managers.FadeIn(TransType.Entry));
        }
        prevPos = gameObject.transform.position;
        challenges = Enumerable.Range(0, 4).ToList();
        variables = GameObject.Find("Variables").GetComponent<Variables>();

        currentScene = SceneManager.GetActiveScene();
        variables.sceneName = currentScene.name;

        if (Variables.managers.puta.Contains(Variables.managers.sceneName)) 
            GameObject.FindGameObjectWithTag("Boss").gameObject.SetActive(false);

        switch (currentScene.name)
        {
            case "Elyiano":
                completedChallenges = variables.challengesCompletedElyiano;
                break;
            case "Magicant":
                completedChallenges = variables.challengesCompletedMagicant;
                break;
            case "LaPuta":
                completedChallenges = variables.challengesCompletedLaPuta;
                break;
            case "Konohagakure":
                completedChallenges = variables.challengesCompletedKonohagakure;
                break;
            case "Neovice":
                completedChallenges = variables.challengesCompletedNeovice;
                break;
            case "Kernel":
                kernel = true;
                break;
        }
        if (variables.challengeCompleted)
        {
            if (!Variables.managers.boss)
            {
                Variables.managers.score += 1;
                completedChallenges.Add(variables.currentChallenge);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Boss").gameObject.SetActive(false);
                Variables.managers.score += 3;
                Variables.managers.puta.Add(currentScene.name);
                if (Variables.managers.puta.Count == 4) {
                    Variables.managers.portales["Neovice"] = 1;
                }
                else if (Variables.managers.puta.Count == 5) {
                    Variables.managers.portales["Kernel"] = 1;
                }
                else {
                    DialogSystem.Manager.onDialogFinish.AddListener(SelectButtons.Manager.ActivateButtons);
                    DialogSystem.Manager.StartConversation(preguntaAbrir);
                }
            }

            if (Variables.managers.score == 35){
                if (Variables.managers.malditoAmin) {
                    DialogSystem.Manager.StartConversation(Variables.managers.dialogoTodosMuertos);
                    Variables.managers.todosMuertos = false;
                }
                else{
                    Variables.managers.todosMuertos = true;
                }
            }
            
            variables.challengeCompleted = false;
        }
        if (Variables.managers.score == 35) Variables.managers.portales["Kernel"] = 1;
        Variables.managers.boss = false;
        foreach(int i in completedChallenges)
            challenges.Remove(i);
    }

    // Update is called once per frame
    void Update()
    {
        if (kernel)
            return;
        else
        {   
            bool moved = prevPos != gameObject.transform.position;
            if (moved)
            {
                int chance = Random.Range(0,1000000);
                prevPos = gameObject.transform.position;
                //Debug.Log(chance);

                if (chance == 69)
                {
                    if (challenges.Count > 0)
                    {
                        Debug.Log("Encuentro");
                        currentChallenge = challenges[Random.Range(0, challenges.Count)];
                        variables.currentChallenge = currentChallenge;
                        variables.position = transform.position;
                        //Load Scene
                        //SceneManager.LoadScene("BattleScene");
                        StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Random, "UI"));

                    }
                }
            }
        }
    }
}
