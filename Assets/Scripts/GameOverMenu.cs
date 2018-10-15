using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour 
{
    public static GameOverMenu instance;
    [SerializeField]
	CanvasGroup canvasGroup = null;

	[SerializeField]
	Text label = null;
    void Awake()
    {
        instance = this;
    }
    public AudioSource EndGameWin;
    // Use this for initialization
    void Start () 
	{

	}

	public void Press()
	{
		SpawnManager.Restart();

        GameManager.instance.construct = 30;

		canvasGroup.alpha = 0.0f;
	}

	public void HandleGameOverConstruct()
	{
		

		if(GameManager.instance.construct >= 100)
		{
			label.text = "Sa traiti,\ndom' Primar!";
            EndGameWin.Play();
            canvasGroup.alpha = 1.0f;
            GameManager.instance.endgame = true;
        }
        if (GameManager.instance.construct <= 0)
        {
			label.text = "Vremuri grele,\nce sa facem?!";
            canvasGroup.alpha = 1.0f;
            GameManager.instance.endgame = true;
        }
	}
}
