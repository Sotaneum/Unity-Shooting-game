using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject [] hazards; 
	public float startWait = 1;
	public float spawnWait = 0.75f;
	public float waveWait=2;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	int score;
	bool gameover;
	bool restart;
	void Start () 
	{
		Screen.SetResolution (480,800,false);
		score = 0;
		gameover = false;
		restart = false;
		UpdateScore ();
		restartText.text = "";
		gameOverText.text = "";
		StartCoroutine (SpawnWaves ());
	}

	public void AddScore(int newScore)
	{
		score += newScore;
		UpdateScore ();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!!!";
		gameover = true;
	}

	void UpdateScore()
	{
		scoreText.text = "Score : "+score;
	}

	IEnumerator SpawnWaves()
	{
		//호출시 1초 후에 뭘 해라
		yield return new WaitForSeconds (startWait);

		while (true) 
		{
			for (int i=0; i<10; ++i) {
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range(-5,5), 5, 16);
				Quaternion spawnRotation = Quaternion.Euler (new Vector3 (0, 180, 0));
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if(gameover==true)
			{
				restartText.text="Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	void Update () 
	{
		if (restart == true) 
		{
			if(Input.GetKeyDown(KeyCode.R)==true)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
