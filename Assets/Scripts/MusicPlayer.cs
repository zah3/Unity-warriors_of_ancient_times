using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;
	
	void Awake(){

			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
	
	}
}
