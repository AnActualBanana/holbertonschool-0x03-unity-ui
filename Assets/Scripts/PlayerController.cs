using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private int score = 0;
	public int health = 5;
	private int originalHealth;
    private int originalScore;
    public float speed = 10.0f; //(acceleration)
    public float maxSpeed = 20.0f;
    public float deceleration = 35.0f;
    private Vector3 velocity = Vector3.zero;
	private void Start()
    {
        originalHealth = health;
        originalScore = score;
    }

    private void Update()
    {
		if (health == 0)
		{
			Debug.Log("Game Over!");
			health = originalHealth;
            score = originalScore;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);

        if (direction.magnitude > 0)
        {
            velocity += direction * speed * Time.deltaTime;
            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        }
        else
        {
            velocity -= velocity.normalized * deceleration * Time.deltaTime;
            if (velocity.magnitude < 0.1f)
            {
                velocity = Vector3.zero;
            }
        }

        transform.position += velocity * Time.deltaTime;
    }
	private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            score++;
            Debug.Log("Score: " + score);
            other.gameObject.SetActive(false);
        }
		else if (other.CompareTag("Trap"))
		{
			health--;
			Debug.Log("Health: " + health);
		}
		else if (other.CompareTag("Goal"))
		{
			Debug.Log("You win!");
		}
    }
}
