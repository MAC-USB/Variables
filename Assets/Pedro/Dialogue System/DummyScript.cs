using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DummyScript : MonoBehaviour
{
    public MonsterSO test;
    public Text testtext;
    private void Start()
    {
        DialogSystem.Manager.StartMonsterDialogRoutine(test, testtext);
    }
}
