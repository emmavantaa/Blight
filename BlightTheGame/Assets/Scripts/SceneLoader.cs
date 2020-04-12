using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
public void NextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+ 1);﻿
	}
}
