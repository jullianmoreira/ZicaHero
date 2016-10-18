using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CarregarCena : MonoBehaviour {

	public void CarregarCenaID(int CenaID)
	{
		SceneManager.LoadScene (CenaID);
	}
}
