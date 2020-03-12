using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monstruo", menuName = "Monstruo")]
public class MonsterSO : ScriptableObject
{
    public Sprite sprite = null;
    public string problem = "problema";
    public string solution = "solucion";
    public string tip = "tip de la maga";
}
