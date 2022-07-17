using UnityEngine;
using Shooter.Scripts.Support;

public class Enemy : MonoBehaviour
{
	protected GameObject player;
	protected float speed;
	protected float health;
	protected float invincibility;
	protected bool wasInvicible;
	protected Elements element;

	void SetElement(Elements element)
	{
		this.element = element;
	}

	void SetPlayer(GameObject player)
	{
		this.player = player;
	}

	void Start()
	{
		health = 1.0f;
		invincibility = 10.0f;
	}

	void OnDamage((Elements, float) tuple)
	{
		if (IsInvincible())
			return;
		health -= tuple.Item2 * ElementalEffectiveness.Effectiveness(tuple.Item1, element);

		if (health <= 0.0f)
			Destroy(this);

		invincibility = 0.0f;
	}

	bool IsInvincible() => invincibility < 2.5f;
	bool IsKnockedBack() => invincibility < 0.5f;

	void Update()
	{
		/* Move towards the player. */
		var px = player.transform.position.x;
		var py = player.transform.position.y;

		var cx = transform.position.x;
		var cy = transform.position.y;

		var direction = new Vector3(px - cx, py - cy, 0.0f);
		direction.Normalize();

		var drag = speed * speed;
		var accel = IsKnockedBack() ? 0.0f : 0.01f;

		speed += (accel - drag) * Time.fixedDeltaTime;
		transform.position += direction * speed;

		/* Handle the i-frame counter and animation. */
		if (IsInvincible())
		{
			wasInvicible = true;
			invincibility += Time.fixedDeltaTime;
			var rate = 2.0f;
			var anim = Mathf.Sin(rate * Mathf.PI * invincibility);

			var color = GetComponent<SpriteRenderer>().color;
			color.a = anim < 0.0f ? 0.0f : 1.0f;

			GetComponent<SpriteRenderer>().color = color;
		}
		else if(wasInvicible)
		{
			wasInvicible = false;
			var color = GetComponent<SpriteRenderer>().color;
			color.a = 1.0f;

			GetComponent<SpriteRenderer>().color = color;
		}
	}
}
