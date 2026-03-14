using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    // --- COMPONENT REFERENCES ---
    // These hold references to other parts of the NPC or the Pathfinding system
    private AIDestinationSetter _aiDestinationSetter;
    private AIPath _aiPath;
    private Rigidbody2D _rigidbody;
    public GameObject _spawnPoints;

    // --- TARGETS & POINTS ---
    // These track where the NPC is, where it’s going, and potential destinations
    private readonly List<GameObject> _points = new List<GameObject>(); // List of all possible spawn/target points
    private int index = 0;
    public GameObject startPoint;    // Where the NPC just came from
    public GameObject destination;   // The final target point
    public GameObject sideTarget;    // An invisible point used to steer around obstacles

    // --- SETTINGS ---
    // Numbers that control how the NPC behaves
    public float detectionRadius = 2f; // How wide the "sensor" circle is
    public float detectMul = 2f;       // How far in front the NPC looks
    public float sideMove = 1f;        // How far to the side the NPC steers to avoid others
    public LayerMask obstacleLayer;    // Which layers count as obstacles

    // --- INTERNAL STATE ---
    // Variables used to track what the NPC is doing right now
    public Vector3 detectionPoint;     // The actual position of the "sensor" in front of the NPC
    private bool _isDiverting = false; // Is the NPC currently trying to go around something?

    public float speed = 10;
    public float speedIncTime = 20f; 

    private void Start() 
    {
        //speed = Random.Range(5, 12);
        carLayer = LayerMask.NameToLayer("Car");
        // 1. Link the code to the components attached to this NPC
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _aiPath = GetComponent<AIPath>();
        _rigidbody = GetComponent<Rigidbody2D>();

        // 2. Setup the "Side Target" used for steering
        sideTarget = transform.Find("SideTarget").gameObject;
        if (sideTarget != null) {
            sideTarget.transform.SetParent(null); // Detach it so it can move freely in the world
        }

        // 3. Find all spawn points in the scene and put them in the list
        //_spawnPoints = GameObject.Find("SpawnPoints");
        for (int i = 0; i < _spawnPoints.transform.childCount; i++) {
            _points.Add(_spawnPoints.transform.GetChild(i).gameObject);
        }
        
        // 4. Pick a random starting point and teleport there
        startPoint = _points[0];  
        gameObject.transform.position = startPoint.transform.position;
        
        GetDestination();
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncTime);
            speed += 0.05f;
        }
    }
    private void GetDestination()
    {
       // Pick a random point that is NOT the one we are currently at
       destination = startPoint;
        
       index++;
       
        if (index >= _points.Count)
        {
            index = 0;
            gameObject.transform.position = _points[index].transform.position;
            index++;    
            ScoreController.instance.AddPoint();
        }

        destination = _points[index];

        _aiDestinationSetter.target = destination.transform;
    }

    public void Update() 
    {
        // Keep the NPC strictly on the 2D plane (Z = 0)
        transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);

        // CHECK: Did we arrive?
        if (_aiPath.reachedDestination) {
            if (_aiDestinationSetter.target == sideTarget.transform) {
                // If we finished "swerving," go back to the original destination
                _aiDestinationSetter.target = destination.transform;
                _isDiverting = false;
            }
            else {
                // If we reached a main point, pick a new one
                startPoint = destination;
                GetDestination();     
            }
        }


    }

    // DRAWING: Shows the detection circle in the Unity Editor Scene view
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(detectionPoint, detectionRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.CompareTag("light"))
       {
            if (!collision.transform.GetComponent<LightChanger>().isGreen)
            {
                _aiPath.maxSpeed = 0;
            }
       }

      


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("light"))
        {
            if (collision.transform.GetComponent<LightChanger>().isGreen)
            {
                _aiPath.maxSpeed = speed;
            }
        }
    }

    private int carLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == carLayer)
        {
            ScoreController.instance.ShowEndPanel();
        }
    }


}