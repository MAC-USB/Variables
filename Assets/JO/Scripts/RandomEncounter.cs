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
    public Material TransitionMaterial;

    // Start is called before the first frame update
    void Start()
    {
        SimpleBlit.managers.FadeIn(TransType.Entry);
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
        }
        if (variables.challengeCompleted)
        {
            //Debug.Log("Completado");
            if (!Variables.managers.boss)
            {
                Variables.managers.score += 1;
                completedChallenges.Add(variables.currentChallenge);
            }
            else
            {
                Variables.managers.score += 3;
                Variables.managers.puta.Add(currentScene.name);
            }

            variables.challengeCompleted = false;
        }
        Variables.managers.boss = false;
        foreach(int i in completedChallenges)
            challenges.Remove(i);
    }

    // Update is called once per frame
    void Update()
    {
        bool moved = prevPos != gameObject.transform.position;
        if (moved)
        {
            int chance = Random.Range(0,100);
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
                    variables.position = transform.position;
                    StartCoroutine(SimpleBlit.managers.FadeOut(TransType.Random, "UI"));

                }
            }
        }
    }
    IEnumerator FadeIn(){
        float progress = 1;
        TransitionMaterial.SetFloat("_Cutoff", progress);
        while (progress > 0){
            progress = Mathf.Clamp(progress - 0.0069f, 0f, 1f);
            TransitionMaterial.SetFloat("_Cutoff", progress);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator FadeOut(){
        float progress = 0;
        TransitionMaterial.SetFloat("_Cutoff", progress);
        while (progress < 1){
            progress = Mathf.Clamp(progress + 0.0069f, 0f, 1f);
            TransitionMaterial.SetFloat("_Cutoff", progress);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("UI");
    }
}
