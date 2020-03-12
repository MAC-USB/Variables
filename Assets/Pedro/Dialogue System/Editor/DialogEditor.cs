using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ConversationSO))]
public class DialogEditor : Editor
{
    private ConversationSO t;
    private int toRemove = 0;

    private void OnEnable()
    {
        t = (ConversationSO)target;
        if (t.dialogsSO == null) t.dialogsSO = new List<DialogSO>();
    }

    public override void OnInspectorGUI()
    {
        DrawGeneralSO();
        EditorUtility.SetDirty(t);
    }   

    void DrawGeneralSO()
    {
        if (GUILayout.Button("Agregar nuevo dialogo")) {
            if (t.dialogsSO == null) t.dialogsSO = new List<DialogSO>();
            t.dialogsSO.Add(new DialogSO());
            toRemove = t.dialogsSO.Count - 1;
        }
        
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Quitar dialogo")) {
            if (toRemove < t.dialogsSO.Count) t.dialogsSO.RemoveAt(toRemove);
        }
        toRemove = EditorGUILayout.IntField(toRemove);
        EditorGUILayout.EndHorizontal();
        
        if (t.dialogsSO.Count > 0) {
            DrawDialogsBoxesSO();
        }
        EditorUtility.SetDirty(t);
    }


    void DrawDialogsBoxesSO()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Lista de dialogos:");
        for (int i = 0; i < t.dialogsSO.Count; i++)
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUIStyle style = GUIStyle.none;
            style.fontStyle = FontStyle.Bold;

            EditorGUILayout.LabelField("Dialogo: " + i, style);

            EditorGUILayout.LabelField("Personaje:");
            EditorGUILayout.BeginHorizontal();
            t.dialogsSO[i].talker = (Characters)EditorGUILayout.EnumPopup(t.dialogsSO[i].talker, GUILayout.Width(100));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Texto:");
            EditorGUILayout.BeginHorizontal();
            style = new GUIStyle(EditorStyles.textArea);
            style.wordWrap = true;
            t.dialogsSO[i].dialog = EditorGUILayout.TextArea(t.dialogsSO[i].dialog, style, GUILayout.MaxWidth(200), GUILayout.MinHeight(70));

            if (GUILayout.Button("-", GUILayout.MaxWidth(30)))
            {
                t.dialogsSO.RemoveAt(i);
                if (t.dialogsSO.Count == 0) i = 0;
                else i--;
                // Desfocusea la vaina
                GUI.FocusControl(null);
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndVertical();
    }


    void DrawDialogsBoxes()
    {

        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Lista de dialogos:");
        for (int i = 0; i < t.dialogs.Count; i++)
        {
            GUIStyle style = GUIStyle.none;
            style.fontStyle = FontStyle.Bold;

            EditorGUILayout.LabelField("Dialogo: " + i, style);

            EditorGUILayout.BeginHorizontal();
            style = new GUIStyle(EditorStyles.textArea);
            style.wordWrap = true;
            t.dialogs[i] = EditorGUILayout.TextArea(t.dialogs[i], style, GUILayout.MaxWidth(200), GUILayout.MinHeight(70));

            if (GUILayout.Button("-", GUILayout.MaxWidth(30))) {
                t.dialogs.RemoveAt(i);
                if (t.dialogs.Count == 0) i = 0;
                else i--;
                // Desfocusea la vaina
                GUI.FocusControl(null);
            }

            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }
}
