using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ChessMovement : MonoBehaviour
{
    public bool mouseOnMe;
    public bool canMove;
    public bool moveHere;
    public LayerMask chessPieceLayerMask;
    public GameObject shadowGameObject;
    public string orgName;
    public string current = "currentPiece";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        orgName = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 18)));
        if(Input.GetMouseButtonDown(0) && mouseOnMe == true)
        {
            canMove = !canMove;
            this.gameObject.name = current;
        }
        if(Input.GetMouseButtonDown(0) && mouseOnMe == false && moveHere == false)
        {
            
        }
        if(canMove == true) 
        {
            PawnLogic();
        }
        if(canMove == false && this.gameObject.tag != "Shadow")
        {
            this.gameObject.name = orgName;
            if (GameObject.FindGameObjectWithTag("Shadow"))
            {
                Destroy(GameObject.FindGameObjectWithTag("Shadow"));
            }
        }
    }

    void PawnLogic()
    {
        RaycastHit hitForward;
        RaycastHit hitRightDiagonal;
        RaycastHit hitLeftDiagonal;
        //check squares infront for movement and diagonals for taking;
        Physics.Raycast(transform.position, transform.forward, out hitForward, 10f, chessPieceLayerMask);
        Physics.Raycast(transform.position, transform.forward + transform.right, out hitRightDiagonal, 15f, chessPieceLayerMask);
        Physics.Raycast(transform.position, transform.forward + -transform.right, out hitLeftDiagonal, 15f, chessPieceLayerMask);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.blue);
        Debug.DrawRay(transform.position, (transform.forward + transform.right) * 10, Color.magenta);
        Debug.DrawRay(transform.position, (transform.forward + -transform.right) * 10, Color.red);   
        
        if(hitForward.collider != null)
        {
            //Can't move to space
            
           // Debug.Log("Space has " + hitForward.collider.name);
        }
        else
        {
            //Can move to space, instantiate shadow to show where can move
            Instantiate(shadowGameObject, new Vector3(transform.position.x, transform.position.y, transform.position.z + 10f), Quaternion.identity);
            if(Input.GetMouseButtonDown(0) && moveHere == true)
            {
                transform.position = GameObject.FindGameObjectWithTag("Shadow").transform.position;
                Destroy(GameObject.FindGameObjectWithTag("Shadow"));
            }
           // Debug.Log("Space is empty");
        }

        if(hitRightDiagonal.collider != null) 
        {
            //can move to space, instantiate shadow to show where can move
            //Debug.Log("You can take the " + hitRightDiagonal.collider.name + " on this space");
        }
        else
        {
            //can't move to space
          //  Debug.Log("There is nothing to take");
        }

        if (hitLeftDiagonal.collider != null)
        {
            //if opposite colour piece
            //can move too space, instantiate shadow to show where can move
           // Debug.Log("You can take the " + hitLeftDiagonal.collider.name + " on this space");
        }
        else
        {
            //can't move to space
           // Debug.Log("There is nothing to take");
        }
    }
    void RookLogic()
    {

    }
    void KnightLogic()
    {

    }
    void BishopLogic()
    {

    }
    void QueenLogic()
    {

    }
    void KingLogic()
    {

    }

    private void OnMouseEnter()
    {
       // Debug.Log(this.gameObject.tag);
        if (this.tag != "Shadow")
        {
            mouseOnMe = true;
        }
        if(gameObject.GetComponent<BoxCollider>().tag == "Shadow")
        {
            moveHere = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "m")
        {
            Debug.Log("Collided with mouse");
            GameObject.Find(current).GetComponent<ChessMovement>().moveHere = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "m")
        {
            Debug.Log("Collided with mouse");
            GameObject.Find(current).GetComponent<ChessMovement>().moveHere = true;
        }
    }

    private void OnMouseExit()
    {
        mouseOnMe = false;
       // moveHere = false;
    }


}


// Get mouse position from camera to world point
//Mouse is 2d vector x, y
//world point is 3d x, y, z
//Top down view so mouse position = x and z of world position