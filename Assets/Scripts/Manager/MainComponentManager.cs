﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class MainComponentManager {
	private static MainComponentManager instance;
	public static void CreateInstance () {
		if (instance == null) {
			instance = new MainComponentManager ();
			GameObject go = GameObject.Find ("Main");
			if (go == null) {
				go = new GameObject ("GlobalManagers");
				go.transform.parent = GameObject.FindWithTag ("ManagerGameObject").transform;
				Object.DontDestroyOnLoad (GameObject.FindWithTag ("ManagerParent"));
				Object.DontDestroyOnLoad (GameObject.FindWithTag ("SceneManager"));
				instance.main = go;
				// important: make game object persistent:
				Object.DontDestroyOnLoad (go);
			}
			Component stateManager = StateManager.SharedInstance;
		}
	}
	
	GameObject main;
	
	public static MainComponentManager SharedInstance {
		get {
			if (instance == null) {
				CreateInstance ();
			}
			return instance;
		}
	}
	
	public static T AddMainComponent <T> () where T : UnityEngine.Component {
		T t = SharedInstance.main.GetComponent<T> ();
		if (t != null) {
			return t;
		}
		return SharedInstance.main.AddComponent <T> ();
	}

}
