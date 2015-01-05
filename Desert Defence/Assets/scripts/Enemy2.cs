using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour
{
	[HideInInspector]
	public Vector3
		waypointPos;
	private float WPcd = 0.5f;
	public float baseSpeed = 2f;
	[HideInInspector]
	public float
		speed;
	private int mtWP2 = 0;
	[HideInInspector]
	public float
		health;
	public float baseHealth = 0f;
	public float healthMultiplier = 1f;
	public int gearYield = 1;
	public int pointYield = 1;
	public int unitDamage;
	[HideInInspector]
	public bool
		slowed = false;
	[HideInInspector]
	public bool
		bleeding = false;
	[HideInInspector]
	public float
		timeSlowed = 8f;
	[HideInInspector]
	public float
		slowTimer = 0f;
	[HideInInspector]
	public int
		tickDamage;
	[HideInInspector]
	public int
		tickLength;
	[HideInInspector]
	public int
		tickInterval;
	[HideInInspector]
	public float
		tickDelay;
	[HideInInspector]
	public int
		tickCount;
	private Vector3 targetPoint;
	private Quaternion targetRotation;
	private EnemySpawn2 enemySpawner2;
	Path2 path2;
	[HideInInspector]
	public GameManager
		gameMgr;
	private Color baseColor;
	
	void Start ()
	{
		gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		path2 = GameObject.Find ("Path2").GetComponent<Path2> ();
		health = baseHealth * (enemySpawner2.wave / 3) * healthMultiplier;
		speed = baseSpeed;
		slowTimer = timeSlowed;
		baseColor = transform.renderer.material.color;
	}
	
	void Update ()
	{
		//Debug.Log (health);
		float step = speed * Time.deltaTime;
		WPcd -= Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, path2.moveToWP2 [mtWP2].position, step);
		waypointPos = path2.moveToWP2 [mtWP2].position;
		LookAt ();
		if (health <= 0) 
		{
			gameMgr.gears += gearYield;
			gameMgr.score += pointYield * enemySpawner2.wavePoints;
			Destroy (gameObject);
			
		}
		if (slowed == true) {
			slowTimer -= Time.deltaTime;
			transform.renderer.material.color = new Color (0F, 244F, 255F, 0.5F);
			//Debug.Log (slowTimer);
			if (slowTimer <= 0) {
				CancelSlowed ();
			}
		}
		if (bleeding == true) {
			if (slowed == true) {
				CancelSlowed ();
			}
			if (tickCount >= tickLength) {
				CancelInvoke ("DoT");
				transform.renderer.material.color = baseColor;
				bleeding = false;
				tickCount = 0;
			}
			
		}
	}
	
	public virtual void LookAt () //Rotates towards the target waypoint
	{
		if (path2.moveToWP2 != null) {
			targetPoint = new Vector3 (path2.moveToWP2 [mtWP2].position.x, transform.position.y, path2.moveToWP2 [mtWP2].position.z) - transform.position;
			targetRotation = Quaternion.LookRotation (-targetPoint, Vector3.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * 4.0f);
		}
	}
	
	void OnTriggerEnter (Collider collision) //What happens when the enemy  collides with....
	{//Upon collision, do...
		if (collision.gameObject.tag == "Waypoint" && WPcd <= 0) { //...the target Waypoint.
			
			mtWP2++;
			WPcd = 0.5f;
			
			if (mtWP2 >= path2.moveToWP2.Length)
			{		//If the index of MoveToTarget exceeds the length of the array, do...
				gameMgr.health -= unitDamage;
				Destroy (gameObject);
			}
			
			
		} 
	}
	
	public void StartDoT ()
	{ //Start Damage over Time.
		InvokeRepeating ("DoT", tickDelay, tickInterval);
		
	}
	
	public void DoT () //Damage over Time.
	{
		//Debug.Log ("Tick Tock");
		health -= tickDamage;
		transform.renderer.material.color = new Color (255F, 0F, 0F, 0.5F);
		tickCount++;
	}
	
	public void CancelSlowed ()
	{
		speed = baseSpeed;
		slowed = false;	
		transform.renderer.material.color = baseColor;
		slowTimer = 0;
	}
	
	public int PriorityLevel ()
	{
		return mtWP2;
	}
	
	public void setSpawner2 (EnemySpawn2 enemySpawn)
	{ //Sets the allocated spawner as spawner.
		enemySpawner2 = enemySpawn; 
		
	}
}