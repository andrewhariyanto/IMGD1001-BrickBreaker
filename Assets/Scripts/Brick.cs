using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] states;
    public int health { get; private set; }
    public int points = 100;
    public bool unbreakable;

    private Shake shake;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    private void Start()
    {
        ResetBrick();
    }

    public void ResetBrick()
    {
        this.gameObject.SetActive(true);

        if(!unbreakable)
        {
            this.health = this.states.Length;
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
    }

    private void Hit()
    {
        if (this.unbreakable) {
            return;
        }

        shake.CamShake();

        addEffect();

        this.health--;
        FindObjectOfType<AudioManager>().Play("Hit");

        if (this.health <= 0) {
            this.gameObject.SetActive(false);
        } else {
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }

        FindObjectOfType<GameManager>().HitNew(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball") {
            Hit();
        }
    }

    private void addEffect() {
        if (this.health == 6) {
            FindObjectOfType<Ball>().ChangeMultiplier(1.35f);
        }
        else if (this.health == 5) {
            FindObjectOfType<Ball>().Fade();
        }
    }

}

