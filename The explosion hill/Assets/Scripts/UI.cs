using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour {

    Canvas Canvas;

    private void Awake()
    {
        Canvas = FindObjectOfType<Canvas>();
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
        RenderSettings.ambientLight = Color.white * 0.7f;
    }

    // Use this for initialization
    void Start () {
        Canvas.enabled = false;
	}
	
	// Update is called once per frame
	public void TryAgain () {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
