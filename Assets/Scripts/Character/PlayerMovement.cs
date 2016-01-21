using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Vector3 m_CamForward;
    private CharacterController controller;
    public Weapon weapon;

    public float speed;
    public bool enableMouseMovement = false;
    
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        HandleKeyboardMovement();
        HandleMouseInput();
        HandleAttackInput();
        
	}

    private void HandleAttackInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            weapon.HandleAttack();
        }
    }

    private void HandleMouseInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float horizontalMovement = 0.0f;
        float verticalMovement = 0.0f;

        RaycastHit hit;
        int layerMask = 1 << 8;
        //layerMask = ~layerMask;
        if (Physics.Raycast(ray, out hit, layerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);

            horizontalMovement = hit.point.x - transform.position.x;
            verticalMovement = hit.point.z - transform.position.z;

            if (Input.GetMouseButton(0))
            {
                Vector3 movement = new Vector3(horizontalMovement, 0.0f, verticalMovement).normalized;

                controller.SimpleMove(movement * speed);
            }

            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));

        }
    }

    private bool HandleKeyboardMovement()
    {
        // read inputs
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (h != 0 || v != 0)
        {
            Vector3 movement = new Vector3(h, 0.0f, v);

            controller.SimpleMove(movement * speed);

            return true;
        }
        return false;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Item selectedObject = hit.transform.gameObject.GetComponent<Item>();

        if(selectedObject != null)
        {
            selectedObject.HandleSelection();
        }
    }

}
