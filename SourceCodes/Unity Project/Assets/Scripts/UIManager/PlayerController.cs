using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed = 2.5f;

    Rigidbody2D myRigidbody;

    [SerializeField]
    Vector3 change;

    private bool inventory;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>(); // Get the rigidbody of the player
    }

    // Update is called once per frame
    void Update()
    {

        change = Vector3.zero;
        change.x = Input.GetAxis("Horizontal"); // Get horizontal and vertical input
        change.y = Input.GetAxis("Vertical");
        if(change != Vector3.zero)
        {
            MoveCharacter(); // if there is a change, move the character
        }
    }

    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime); // Move the rigidbody smoothly
        if (Input.GetKey(KeyCode.LeftShift)) // If the player pressed shift
        {
            myRigidbody.MovePosition(transform.position + change * speed * 2 * Time.deltaTime); // Move the player at double the speed
        }
    }
}