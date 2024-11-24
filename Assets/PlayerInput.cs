using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameObject playerCharacter;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask floorLayer;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private float cameraSpeed;

    private bool inGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inGame)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;
                if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, float.MaxValue, floorLayer))
                {
                    playerCharacter.GetComponent<NavMeshAgent>().destination = hit.point;
                }
            }
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                direction.z = -1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                direction.z = 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                direction.x = 1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                direction.x = -1;
            }
            Vector3 movement = direction.normalized * cameraSpeed;
            cam.transform.position += movement;
        }
    }

    public void startGame()
    {
        mainMenu.gameObject.SetActive(false);
        inGame = true;
    }
}
