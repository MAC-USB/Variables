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

    // Start is called before the first frame update
    void Start()
    {
        prevPos = gameObject.transform.position;
        challenges = Enumerable.Range(0, 4).ToList();
        variables = GameObject.Find("Variables").GetComponent<Variables>();

        currentScene = SceneManager.GetActiveScene();
        variables.sceneName = currentScene.name;
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
                completedChallenges = variables.challengesCompletedKernel;
                break;
        }
        if (variables.challengeCompleted)
        {
            //Debug.Log("Completado");
            completedChallenges.Add(variables.currentChallenge);
            variables.challengeCompleted = false;
        }
        foreach(int i in completedChallenges)
            challenges.Remove(i);
    }

    // Update is called once per frame
    void Update()
    {
        bool moved = prevPos != gameObject.transform.position;
        if (moved)
        {
            int chance = Random.Range(0,1000);
            prevPos = gameObject.transform.position;
            //Debug.Log(chance);

            if (chance == 69)
            {
                if (challenges.Count > 0)
                {
                    Debug.Log("Encuentro");
                    currentChallenge = challenges[Random.Range(0, challenges.Count)];
                    variables.currentChallenge = currentChallenge;
                    //Load Scene
                    //SceneManager.LoadScene("BattleScene");
                    variables.challengeCompleted = true;
                    variables.position = transform.position;
                    Debug.Log(currentChallenge);
                    SceneManager.LoadScene(currentScene.name);
                }
            }
        }
    }
}
