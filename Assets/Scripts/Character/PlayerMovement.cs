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
        if (!HandleKeyboardMovement())
        {
            if (enableMouseMovement)
                HandleMouseInput();
        }
        HandleAttackInput();
        
	}

    private void HandleAttackInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SPACE");
            weapon.HandleAttack();
        }
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            int layerMask = 1 << 8 ;
            //layerMask = ~layerMask;
            if (Physics.Raycast(ray, out hit, layerMask))
            {
                Debug.DrawRay(ray.origin,ray.direction * hit.distance, Color.yellow);
               
                float h = hit.point.x - transform.position.x;
                float v = hit.point.z - transform.position.z;
                Vector3 movement = new Vector3(h, 0.0f, v).normalized;

                controller.SimpleMove(movement * speed);
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white);
            }
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
