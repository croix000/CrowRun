using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectSpawner : MonoBehaviour
{
	[SerializeField]
	Vector3 ObtaclePos;
	[SerializeField]
	Vector3 ObtaclePosL;
	[SerializeField]
	Vector3 ObtaclePosR;

    float timer;
	[SerializeField]
	float ObstacleSpawnSpeed = 3.5f;
    int selectedLane;
    float totalTimeElapsed;
    int timeID;


	[SerializeField]
	GameObject obstaclePrefab;


	[SerializeField]
	GameObject coinPrefab;


	[SerializeField]
	GameObject goalPrefab;

	[SerializeField]
	Slider slider;


	private bool gameEnded;
	// Update is called once per frame
	void Update()
	{


		totalTimeElapsed += Time.deltaTime;
		slider.value = totalTimeElapsed /5;

		if (slider.value > 0.99f){
			GameEnded();
			return;
		}

		timeID = (int)totalTimeElapsed * 1;
		if (ObstacleSpawnSpeed > timer)
		{

			timer += Time.deltaTime;
		}
		else
		{
			timer = 0;

			SpawnObstacleAndCoin();

		}

		void SpawnObstacleAndCoin()
		{
			GameObject goObstacle = GameObject.Instantiate(obstaclePrefab);
			goObstacle.name = "Obstacle" + timeID.ToString();


			GameObject goCoin = GameObject.Instantiate(coinPrefab);
			goCoin.name = "Coin" + timeID.ToString();

			selectedLane = Random.Range(0, 3);

			PlacePrefab(selectedLane, goObstacle);

			int randomPos = Random.Range(0, 1);
			randomPos = (randomPos == 0 ) ? -1 : 1;
			PlacePrefab(selectedLane, goObstacle);
			PlacePrefab((selectedLane+randomPos)%3, goCoin);

		}
	}

	void PlacePrefab(int lane, GameObject gameObject) {

		switch (lane)
		{
			case 0: //Mid
				{
					gameObject.transform.position = ObtaclePos;
					break;
				}

			case 1: //Rigtht 
				{
					gameObject.transform.position = ObtaclePosR;
					break;
				}
			case 2: //Left
				{
					gameObject.transform.position = ObtaclePosL;
					break;
				}

		}

	}

	void GameEnded() {

		if (gameEnded)
			return;
		else {
			gameEnded=true;
		}

		GameObject goGoal = GameObject.Instantiate(goalPrefab);
		PlacePrefab(0, goGoal);
	}

}
