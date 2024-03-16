using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//
// The team is looking to make a game similar to Space Invaders and you've started with making an
// enemy that shoots lasers towards the player at the bottom of the screen. You've come up with the
// following solution that fires a laser at random intervals that works, however yourself and your team
// have noticed occassional stuttering when testing.
//
// You can assume no compile errors and that any references are correctly linked in the Unity inspector.
//
// 1. Why might we be seeing stuttering?
// 2. Make any changes/additions to prevent potential stuttering issues.
//
public class GameController : MonoBehaviour
{
	[SerializeField]
	GameObject laserObject;

	[SerializeField]
	GameObject enemyObject;

	List<GameObject> lasers = new();

	[SerializeField]
	public OptimizePool laserPool;

	const float MIN_FIRE_TIME = 0.2f;
	const float MAX_FIRE_TIME = 0.8f;
	const float MIN_Y_BOUNDS = -10f;
	const int LASER_SPEED = 4;

	float ENEMY_MOVE_TIME = 3;
	public void Start()
	{
		FireLaser();
	}

	void FireLaser()
	{
		// Known issue: Enemy object is fixed in location, lasers will only fire -- RESOLVED
		// from the same x position
		var laser = Instantiate(laserObject, enemyObject.transform);
		lasers.Add(laser);

		// Fire another laser after a random time has passed
		var randomTime = Random.Range(MIN_FIRE_TIME, MAX_FIRE_TIME);
		Invoke(nameof(FireLaser), randomTime);
	}


	void EnemyPositionChange()
	{
		// This should make the enemy object's location be random within the gameplay.
		if (ENEMY_MOVE_TIME <= 0)
		{
			enemyObject.transform.position = transform.position + new Vector3(Random.Range(-7.5f, 7.5f ),Random.Range(-4.19f, 3.3f), 0f);
			ENEMY_MOVE_TIME = 4;
		}
		else
		{
			ENEMY_MOVE_TIME -= Time.deltaTime;
		}			
		
	}

	public void Update()
	{
		EnemyPositionChange();

		for (var i = 0; i < lasers.Count; i++)
		{
			var laser = lasers[i];
			laser.transform.Translate(Vector3.down * LASER_SPEED * Time.deltaTime);
			

			if (laser.transform.position.y < MIN_Y_BOUNDS)
			{
				// As the laser is not on screen anymore, remove the laser from the scene
				lasers.RemoveAt(i);
				Destroy(laser);
				i--;
			}
		}
	}
}
