using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform spawn;
    [SerializeField] private MeshRenderer startWallMesh;
    [SerializeField] private BoxCollider startWallCollider;
    [SerializeField] private Boss boss;
    [SerializeField] private BallCollisions ballCollisions;
    [SerializeField] private Collider ballCollider;
    public int currentBall;

    private void Update()
    {
        scoreManager.BestScore();
    }

    public void Respawn()
    {
        ballCollider.enabled = true;
        Destroy(ballCollisions.clones);
        ballTransform.position = spawn.position;
        startWallMesh.enabled = false;
        startWallCollider.isTrigger = true;
        boss.ResetBoss();
        ballCollisions.ResetBallCollision();
        scoreManager.ResetScore();
    }
}
