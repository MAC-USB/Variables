using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum TransType {Boss, Portal, Random, Entry}

[ExecuteInEditMode]
public class SimpleBlit : MonoBehaviour
{
    public static SimpleBlit managers{get;private set;}

    public Material TransitionMaterial;
    public Material boss;
    public Material portal;
    public Material random;
    public Material entry;

    void Awake(){
    #region  Singleton
        if(managers != null && managers != this){
            Debug.LogWarning("Mira mamaguevo hay 2 SimpleBlits");
            Destroy(gameObject);
        }
        managers = this;
    #endregion
    }
    void Start(){
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (TransitionMaterial != null)
            Graphics.Blit(src, dst, TransitionMaterial);
    }
    public IEnumerator FadeIn(TransType trans){
        switch (trans){
            case TransType.Boss:
                TransitionMaterial = boss;
                break;
            case TransType.Portal:
                TransitionMaterial = portal;
                break;
            case TransType.Random:
                TransitionMaterial = random;
                break;
            case TransType.Entry:
                TransitionMaterial = entry;
                break;
        }
        float progress = 1;
        TransitionMaterial.SetFloat("_Cutoff", progress);
        while (progress > 0){
            progress = Mathf.Clamp(progress - 0.0069f, 0f, 1f);
            TransitionMaterial.SetFloat("_Cutoff", progress);
            yield return new WaitForSeconds(0.01f);
        }
    }
    public IEnumerator FadeOut(TransType trans, string targetScene){
        switch (trans){
            case TransType.Boss:
                TransitionMaterial = boss;
                break;
            case TransType.Portal:
                TransitionMaterial = portal;
                break;
            case TransType.Random:
                TransitionMaterial = random;
                break;
            case TransType.Entry:
                TransitionMaterial = entry;
                break;
        }
        float progress = 0;
        TransitionMaterial.SetFloat("_Cutoff", progress);
        while (progress < 1){
            progress = Mathf.Clamp(progress + 0.0069f, 0f, 1f);
            TransitionMaterial.SetFloat("_Cutoff", progress);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(targetScene);
    }
}
