using UnityEngine;
using System.Collections;

public class WildMonsterAIStateMachine : MonoBehaviour {
	int attackTime=0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		attackTime++;
		if (GetComponent<MonsterBase> () == null) {
			Debug.LogError("no monsterBase");
				}
		if(attackTime>=GetComponent<MonsterBase>().AttackTime*30){
			Collider[] cols = Physics.OverlapSphere (transform.position, GetComponent<MonsterBase>().AttackRange);
			foreach(Collider col in cols)
			{

				if(col.gameObject.tag==Tags.Player)
				{

					float damage=GetComponent<MonsterBase>().Attack;
					//Debug.Log("monster attack"+damage);
					if(damage<0)damage=0;
					col.gameObject.GetComponent<Health>().BeAttack(damage);
				}
			}
			attackTime=0;
		}
	}
}
