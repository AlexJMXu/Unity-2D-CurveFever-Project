using UnityEngine;

public class Snake : MonoBehaviour {
	
	public float speed = 3f;
	public float rotationSpeed = 200f;

	private float horizontal = 0f;

	public string inputAxis = "Horizontal";

	private GameManager gm;

	void Start() {
		gm = GameManager.instance;
	}

	void Update () {
		horizontal = Input.GetAxisRaw(inputAxis);
	}

	void FixedUpdate () {
		transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
		transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "killsPlayer") {
			speed = 0f;
			rotationSpeed = 0f;

			gm.EndGame();
		}
	}
}
