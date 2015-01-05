using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
		public GameManager_1 gameMgr;
		[HideInInspector]
		public TowerSpawner
				towerSpawner;
		public int upgradeCost = 0;
		public int saleValue = 0;
		public bool noMove = true;
		/*[SerializeField]
	protected string
		ammunition = "Bullet";*/
		public int level;
		private Vector3 startPos;
		[SerializeField]
		protected Vector3
				currentPosition;
		public float rotSpeed = 0;
		[SerializeField]
		protected GameObject
				bulletPrf;
		[SerializeField]
		private float
				radius = 3f;
		[SerializeField]
		private float
				secBetweenShots;
		private float cooldown = 0.1f;
		private Transform target;
		public static GameObject closestTarget;
		private Vector3 targetPoint;
		private Quaternion targetRotation;
		[SerializeField]
		private Transform
				barrelLoc;
		private Transform actualBarrelLoc;
		public TowerType type;

		protected virtual void Start ()
		{
				startPos = transform.position;
				if (barrelLoc != null) {
						actualBarrelLoc = barrelLoc;
				} else {
						actualBarrelLoc = transform;
				}
		
		}
	
		public virtual void LookAt ()//Rotates the tower towards the enemy it is targeting.
		{
				if (closestTarget != null) {
						targetPoint = new Vector3 (closestTarget.transform.position.x, transform.position.y, closestTarget.transform.position.z) - transform.position;
						targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up);
						transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
				}
		}
	
		public virtual GameObject FindClosestEnemy ()//Sets the enemy closest to the highest prio waypoint as a target.
		{
				int enemyLayer = LayerMask.NameToLayer ("Enemies");
				Collider[] cols;
				cols = Physics.OverlapSphere (transform.position, radius, 1 << enemyLayer);
				//Debug.Log (cols);
				GameObject closest = null;
				float distance = Mathf.Infinity;
				int priority = -1;
				foreach (Collider col in cols) {
						Enemy t = col.GetComponent<Enemy> ();
						int tempPrio = t.PriorityLevel ();
						if (priority <= tempPrio) {
								Vector3 diff = col.transform.position - t.waypointPos;
								float curDistance = diff.sqrMagnitude;
								if (curDistance < distance) {
										closest = col.gameObject;
										distance = curDistance;
										priority = tempPrio;
								}
						}
				}
				return closest;
		}

		protected virtual void Update ()
		{
		
				cooldown -= Time.deltaTime;
				//transform.position = startPos + Vector3.up * Mathf.Sin (Time.time * 3f) * 0.1f;
				currentPosition = transform.position;
				closestTarget = FindClosestEnemy ();
				LookAt ();
		
		
				if (closestTarget != null && cooldown <= 0) {
						target = closestTarget.transform;
						Fire ();
						cooldown = secBetweenShots;
				}

				if (!noMove) {
						transform.position = startPos + Vector3.up * Mathf.Sin (Time.time) * 0.2f;
				}
		
		}
	
		public virtual void Fire ()//Shoots a bullet.
		{
				//Debug.Log ("Tower fire " + ammunition);
		
		
				GameObject go = Instantiate (bulletPrf, actualBarrelLoc.position, Quaternion.identity) as GameObject;
				// bullet move awake
		
				go.GetComponent<Projectile> ().SetTarget (target);
		
		}

		public void setMGR (GameManager_1 gameMGR)
		{
				gameMgr = gameMGR; 
		}

		public void setTowerSpawn (TowerSpawner towerSpawn)
		{
				towerSpawner = towerSpawn;
		}

		public void Sell ()
		{

				Destroy (transform.root.gameObject);
		}


}
