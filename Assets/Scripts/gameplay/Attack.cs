using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    float AttackTime;//rate of attack, 
    float damage;
    public GameObject attackee;// the obj that being attacked. minions will follow the attackee until out of sight range

    private float attackTime;

	// Use this for initialization
	void Start () {
		if (GetComponent<PlayableBase> () == null)
						Debug.LogError ("dont have playableBase");
		AttackTime = GetComponent<PlayableBase> ().AttackRange;
		damage = GetComponent<PlayableBase> ().Attack;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (attackTime > 0)
            attackTime--;

	}
    public void AttackSimple(GameObject obj)//for minions
    {
        attackee = obj;
        if(attackTime<=0)//attack cool down
        {
            doAttack();
            attackTime = AttackTime;
        }
    
    }
    void doAttack()
    {
		if (tag == Tags.Player) {
			if(GetComponent<HeroBase>()==null)
				Debug.LogError("no heroBase");
			float rand=Random.Range(0f,1.0f);
			if(rand<GetComponent<HeroBase>().CriticalRate)
			{
				damage*=2;
			}	
		}
        attackee.GetComponent<Health>().BeAttack(damage);//need to consider attackee's armor later
        //there should be animation;
        //transform.rigidbody.AddForce(new Vector3(0, 1, 0));

            
    }

}
