using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public SpriteRenderer ballSprite;

    public float speed = 500f;
    public float speedMultiplier = 1f;

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.ballSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;
        this.speedMultiplier = 1f;
        
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        this.rigidbody.AddForce(force.normalized * this.speed * this.speedMultiplier);
    }

    public void ChangeMultiplier(float m) {
        this.speedMultiplier = m;
        float xVelo = this.rigidbody.velocity.x;
        float yVelo = this.rigidbody.velocity.y;
        this.rigidbody.velocity = new Vector2(xVelo, yVelo*speedMultiplier);
    }

    public void Fade() {
        StartCoroutine(FlashImage());
    }

    public IEnumerator FlashImage() {
        for (int i = 0; i < 3; i ++) {
            ballSprite.enabled = false;
            yield return new WaitForSeconds(0.35f);
            ballSprite.enabled = true;
            yield return new WaitForSeconds(0.35f);
        }
    }
}

