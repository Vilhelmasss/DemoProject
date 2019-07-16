using Cinemachine;
using UnityEngine;

public class HawkScript : MonoBehaviour
{
    public CinemachineVirtualCamera cmCamera;
    public GameObject Player;

    private Rigidbody2D rb;
    public float speed;

    void Awake()
    {
        Player = GameObject.Find("Player");
        gameObject.transform.position = new Vector2(Player.transform.position.x, Player.transform.position.y);
    }
    void Start()
    {
        Invoke("DestroyItself", 15f);
        cmCamera = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();
        cmCamera.Follow = gameObject.transform;
        Player.GetComponent<PlayerController>().otherMovement = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
            DestroyItself();

        float moveInputHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInputHorizontal * speed, rb.velocity.y);
        float moveInputVertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, moveInputVertical * speed);
    }

    void DestroyItself()
    {
        cmCamera.Follow = Player.transform;
        Player.GetComponent<PlayerController>().otherMovement = false;
        Player.GetComponent<SummonHawk>().currentCooldown = Player.GetComponent<SummonHawk>().totalCooldown;
        Destroy(gameObject);
    }
}
