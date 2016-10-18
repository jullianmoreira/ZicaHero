using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelecionarNoTeclado : MonoBehaviour {

	public EventSystem ev;
	public GameObject go;
	private bool bs;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Vertical") != 0 && bs == false)
		{
			ev.SetSelectedGameObject (go);
			bs = true;
		}
	}

	private void OnDisable()
	{
		bs = false;
	}
}
