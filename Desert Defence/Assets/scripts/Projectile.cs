using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
		[SerializeField]
		protected GameObject
				particlePrf;
		[SerializeField]
		private float
				damage;
		private Vector3 lastTargPos;
		[SerializeField]
		private int
				speed;
		[SerializeField]
		private float
				speedRot = 100;
		[SerializeField]
		private bool
				slowsTarget = false;
		[SerializeField]
		private float
				slowMultiplier = 1f;
		public float timeSlowed = 8f;
		[SerializeField]
		private bool
				explodesOnHit = false;
		[SerializeField]
		private float
				explosionRadius = 1f;
		[SerializeField]
		private float
				explosionDamage = 50f;
		[SerializeField]
		private bool
				dealsDOT = false;
		[SerializeField]
		private int
				tickDamage = 0;
		[SerializeField]
		private int
				tickLength = 0;
		private int tickInterval = 1;
		private int tickCount = 0;
		private float tickDelay = 1f;
		private Transform target;
		private Vector3 targetPoint;
		private Quaternion targetRotation;
	
		void Awake ()
		{
		
		}
	
		void Update ()
		{
				float step = speed * Time.deltaTime;
				if (target == null) {
						Destroy (gameObject);
						return;
				} else {
						lastTargPos = target.position;

				}
				transform.position = Vector3.MoveTowards (transform.position, lastTargPos, step);
				LookAt ();
		
		
		}

		public virtual void LookAt ()
		{
				if (target != null) {
						Vector3 targetDir = target.position - transform.position;
						float step = speedRot * Time.deltaTime;
						Vector3 newDir = Vector3.RotateTowards (transform.forward, targetDir, step, 0.0F);
						transform.rotation = Quaternion.LookRotation (newDir);
				}
		}
	
		public void SetTarget (Transform targ)
		{
				target = targ;
		}
	
		public void Explode ()// Area of Effect Damage.
		{
				Vector3 explosionPos = transform.position;
				Collider[] colliders = Physics.OverlapSphere (explosionPos, explosionRadius, 1 << 8);
				foreach (Collider hit in colliders) {
						if (hit) {
								Enemy enemy = hit.gameObject.GetComponent<Enemy> ();
								enemy.health -= explosionDamage;
								if (enemy.slowed == false && slowsTarget == true) {
										enemy.timeSlowed = timeSlowed;
										enemy.speed *= slowMultiplier;
										enemy.slowed = true;
										enemy.slowTimer = enemy.timeSlowed;
								}
								if (enemy.bleeding == false && dealsDOT == true) {
										enemy.bleeding = true;
										enemy.tickInterval = tickInterval;
										enemy.tickDamage = tickDamage;
										enemy.tickDelay = tickDelay;
										enemy.tickLength = tickLength;
										enemy.tickCount = tickCount;
										if (enemy.slowed == true) {
												enemy.tickDamage = tickDamage * 2;
										}
										enemy.StartDoT ();


								}
						}
			
				}
		}
	
		void OnTriggerEnter (Collider collision)
		{//Upon collision, do...
				if (collision.gameObject.tag == "Target") {
						Enemy enemy = collision.gameObject.GetComponent<Enemy> ();
						Destroy (gameObject);
						enemy.health -= damage;
						if (enemy.slowed == false && slowsTarget == true) { //Slow Damage.
								enemy.timeSlowed = timeSlowed;
								enemy.speed *= slowMultiplier;
								enemy.slowTimer = enemy.timeSlowed;
								enemy.slowed = true;
						}
						if (explodesOnHit == true) {
								Instantiate (particlePrf, transform.position, Quaternion.identity);
								Explode ();
						}
						if (enemy.bleeding == false && dealsDOT == true) { //DoT Damage.
								enemy.bleeding = true;
								enemy.tickInterval = tickInterval;
								enemy.tickDamage = tickDamage;
								enemy.tickDelay = tickDelay;
								enemy.tickLength = tickLength;
								enemy.tickCount = tickCount;
								if (enemy.slowed == true) {
										enemy.tickDamage = tickDamage * 2;
								}
								enemy.StartDoT ();
						}
				}
			
		}
		
}
