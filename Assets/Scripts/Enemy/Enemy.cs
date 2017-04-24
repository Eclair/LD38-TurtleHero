using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public string displayName;
	public int health;
	public int maxHealth;
	public int attack;
	public float attackCooldown;

	private float sinceLastAttack = 0;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		Animator animator = this.GetComponentInChildren<Animator>();
		if (sinceLastAttack > attackCooldown) {
			if (animator != null) {
				animator.SetBool("attacking", true);
			}
			if (Turtle.instance != null) {
				Turtle.instance.attack(attack);
			}
			// TODO: ATTACK Effect?
			sinceLastAttack = 0;
		} else {
			if (animator != null) {
				animator.SetBool("attacking", false);
			}
			sinceLastAttack += Time.deltaTime;
		}
	}

	void OnMouseDown() {
		BattleControl.instance.tryToAttackEnemy(this);
	}

	public void getHit(int damage) {
		health -= damage;
		Animator animator = this.GetComponentInChildren<Animator>();
		if (animator != null) {
			animator.SetBool("takesDamage", true);
			StartCoroutine(RestoreNormalModeAfter(.4f));
		}
	}

	IEnumerator RestoreNormalModeAfter(float time)
	{
		yield return new WaitForSeconds(time);

		Animator animator = this.GetComponentInChildren<Animator>();
		if (animator != null) {
			animator.SetBool("takesDamage", false);
		}
	}
}
