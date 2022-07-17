using System;
using System.Collections;
using System.Collections.Generic;
using Shooter.Scripts.Support;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public float spawnRate;

	public Sprite fireSprite;
	public Sprite waterSprite;
	public Sprite grassSprite;

	public RuntimeAnimatorController fireAnimatorController;
	public RuntimeAnimatorController waterAnimatorController;
	public RuntimeAnimatorController grassAnimatorController;

	private float accumulator;
	private GameObject baseEnemy;
	private GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
		if (player == null)
			throw new System.Exception("Could not find player object. Make sure it's " +
				"named Player");

		accumulator = 0f;
		baseEnemy = new GameObject();

		baseEnemy.AddComponent<SpriteRenderer>();
		baseEnemy.AddComponent<Collider2D>();
		baseEnemy.AddComponent<Animator>();
		baseEnemy.AddComponent<Enemy>();
		baseEnemy.GetComponent<Enemy>().SendMessage("SetPlayer", player);
	}

	void Update()
	{
		accumulator += Time.fixedDeltaTime;
		
		var spawned = (int)Math.Floor(accumulator * spawnRate);
		accumulator -= (float) spawned / spawnRate;

		Elements element = Elements.WATER;

		for(int i = 0; i < spawned; ++i)
		{
			var enemy = GameObject.Instantiate(baseEnemy);

			var sprite = element == Elements.FIRE ? fireSprite : (element == Elements.WATER ? waterSprite : grassSprite);
			var anim = element == Elements.FIRE ? fireAnimatorController : (element == Elements.WATER ? waterAnimatorController : grassAnimatorController);

			enemy.GetComponent<SpriteRenderer>().sprite = sprite;
			enemy.GetComponent<Animator>().runtimeAnimatorController = anim;

			enemy.transform.position = new Vector3(transform.position.x, transform.position.y);
			enemy.SetActive(true);
		}
	}
}
