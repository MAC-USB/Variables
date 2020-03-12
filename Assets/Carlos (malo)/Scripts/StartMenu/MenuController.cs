using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour {

	Variables variables;
	public GameObject dataController;
	public GameObject macFore;
	public GameObject macBack;
	public GameObject macHeart1;
	public GameObject macHeart2;
	public GameObject start;
	public GameObject sure;
	public GameObject nombre;
	public GameObject messageBox;
	public GameObject inputField;
	public GameObject fondo;
	public Text field;
	public Text holder;
	public InputField input;
//	public AudioManager aM;
	public GameObject cube;

	private int cont = -1;

	void Awake () {
		cube.SetActive (true);
		macFore.SetActive (false);
		macBack.SetActive (false);
		macHeart1.SetActive (false);
		macHeart2.SetActive (false);
		start.SetActive (false);
		fondo.SetActive (false);
		messageBox.SetActive (false);
		inputField.SetActive (false);
		nombre.SetActive (false);
		sure.SetActive (false);

		variables = GameObject.Find("Variables").GetComponent<Variables>();
	}

	void Start()
	{
		//FindObjectOfType<AudioManager> ().Play ("Intro");
	}
	void Update () {
		if (cont == -1 && Input.GetKeyDown (KeyCode.Return))
		{
			cube.SetActive (false);	
			macFore.SetActive (true);
			macBack.SetActive (true);
			macHeart1.SetActive (true);
			macHeart2.SetActive (true);
			start.SetActive (true);
			fondo.SetActive (true);
			cont = 0;
		}
		if (cont == 0)
			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				cont = 1;
			}

		if (cont == 1)
		{
			macFore.SetActive (false);
			macBack.SetActive (false);
			macHeart1.SetActive (false);
			macHeart2.SetActive (false);
			start.SetActive (false);
			fondo.SetActive (false);
			nombre.SetActive (true);
			inputField.SetActive (true);
			cont = 2;
		}

		if (cont == 2) {
			if (Input.GetKeyDown (KeyCode.Return) && !field.text.Equals (string.Empty)) 
			{
				nombre.SetActive (false);
				sure.SetActive (true);
				messageBox.SetActive (true);
				cont = 3;
			}
		}
	
		if (cont == 3) 
		{
			if (Input.GetKeyDown (KeyCode.Y)) 
			{
				string groupName = field.text;
				variables.groupName = groupName;
				//ControlArchivo.ActualizarGrupo (groupName);
				//FindObjectOfType<AudioManager> ().Stop ("Intro");
				SceneManager.LoadScene ("Elyiano");
			}

			if (Input.GetKeyDown (KeyCode.N)) 
			{
				nombre.SetActive (true);
				sure.SetActive (false);
				messageBox.SetActive (false);
				cont = 2;
				input.text = string.Empty;
			}
		}
	}
}
