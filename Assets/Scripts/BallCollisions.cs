using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BallCollisions : MonoBehaviour
{

    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private MeshRenderer startWallMesh;
    [SerializeField] private BoxCollider startWallCollider;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject leftBossDoor;
    [SerializeField] private GameObject rightBossDoor;
    public bool isOpenBossDoor;
    public bool isCloseBossDoor;
    [SerializeField] private float doorSpeed;
    public bool isBossMove;
    [SerializeField] private float bossSpeed;
    [SerializeField] private Transform boss;
    [SerializeField] private Boss bossScript;
    [SerializeField] private GameObject bossButton;
    [SerializeField] private Transform leftDoorSpawn;
    [SerializeField] private Transform rightDoorSpawn;
    private Rigidbody ballRigidbody;
    public GameObject clones;
    [SerializeField] private GameObject cloneSpawn;
    [SerializeField] private Collider ballCollider;


    private void Start()
    {
        ballRigidbody = gameObject.GetComponent<Rigidbody>();
        ballCollider = gameObject.GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        OpenCloseDoor();
        BossMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IsTouchSpring"))
        {
            cameraManager.ActivateCamera();
        }

        if (other.CompareTag("DeathZone"))
        {
            gameManager.currentBall--;
            ballCollider.enabled = false;
            if (gameManager.currentBall<1)
            {
                Debug.Log(gameManager.currentBall);
                gameManager.currentBall = 1;
                gameManager.Respawn();
                ballRigidbody.velocity = Vector3.zero;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StartWall"))
        {
            startWallMesh.enabled = true;
            startWallCollider.isTrigger = false;
        }

        if (other.CompareTag("IsTouchSpring"))
        {
            cameraManager.DesactivateCamera();
        }
        
        if (other.CompareTag("MultipleSpawn"))
        {
            if (clones == null)
            {
                clones = new GameObject("Clones");
                Instantiate(gameObject, cloneSpawn.transform.position, quaternion.identity, clones.transform);
            }
            gameManager.currentBall++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("BossButton"))
        {
            StartCoroutine("IsOpenCloseDoor");
            bossButton.SetActive(false);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            bossScript.SetHealth(1);
        }
        
    }

    IEnumerator IsOpenCloseDoor()
    {
        isOpenBossDoor = true;
        yield return new WaitForSeconds(2f);
        isOpenBossDoor = false;
        isBossMove = true;
        bossScript.SetHealth(0);
        yield return new WaitForSeconds(3f);
        isBossMove = false;
        isCloseBossDoor = true;
        yield return new WaitForSeconds(2f);
        isCloseBossDoor = false;
    }

    void OpenCloseDoor()
    {
        if (isOpenBossDoor)
        {
            leftBossDoor.transform.Translate(Vector3.left * doorSpeed);
            rightBossDoor.transform.Translate(Vector3.right * doorSpeed);
        }
        
        else if (isCloseBossDoor)
        {
            leftBossDoor.transform.Translate(Vector3.right * doorSpeed);
            rightBossDoor.transform.Translate(Vector3.left * doorSpeed);
        }
    }

    void BossMove()
    {
        if (isBossMove)
        {
            boss.Translate(Vector3.back*bossSpeed);
        }
    }

    public void ResetBallCollision()
    {
        isBossMove = false;
        isCloseBossDoor = false;
        isOpenBossDoor = false;
        StopAllCoroutines();
        leftBossDoor.transform.position = leftDoorSpawn.position;
        rightBossDoor.transform.position = rightDoorSpawn.position;
    }
    
    
    
}    
