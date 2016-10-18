using UnityEngine;
using System.Collections;

public class FecharJogo : MonoBehaviour {

	public void Fechar()
	{
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif	
	}
}
