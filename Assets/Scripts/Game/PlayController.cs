using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayController : MonoBehaviour {
	// Use this for initialization
	void Start () {
        vars = ManagerVars.GetManagerVars();
	}
    bool isMoveLeft;
    private Vector3 nextPlatFormLeft;
    private Vector3 nextPlatFormRight;
    bool isJumping = false;
    ManagerVars vars;

    private void Awake()
    {
        
    }
    // Update is called once per frame
    void Update () {

        if (!GameMananger.Intance.isGameStart||GameMananger.Intance.isGameOver)
        {
            return;
            
        }
        if (Input.GetMouseButtonDown(0) && isJumping == false)
        {
            EventCenter.Broadcast(EventDefine.DecidePath);
            isJumping = true;
            Vector3 mousePos = Input.mousePosition;
            if (mousePos.x <= Screen.width / 2)
            {
                isMoveLeft = true;
            }
            else if (mousePos.x > Screen.width / 2)
            {
                isMoveLeft = false;
            }
            Jump();
        }


    }

    void Jump()
    {
        if (isMoveLeft)
        {
            transform.localScale = new Vector3(-10, 10, 1);
            transform.DOMoveX(nextPlatFormLeft.x, 0.2f);
            transform.DOMoveY(nextPlatFormLeft.y + 8f, 0.1f);
        }
        else
        {
           
            transform.DOMoveX(nextPlatFormRight.x, 0.2f);
            transform.DOMoveY(nextPlatFormRight.y + 8f, 0.1f);
            transform.localScale = new Vector3(10, 10, 1);
        }
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlatForm")
        {
            isJumping = false;
            Vector3 currentPlatForm = collision.gameObject.transform.position;
           
            nextPlatFormLeft = new Vector3(currentPlatForm.x - vars.nextXPos, currentPlatForm.y + vars.nextYPos, 0);
            nextPlatFormRight = new Vector3(currentPlatForm.x + vars.nextXPos, currentPlatForm.y + vars.nextYPos, 0);

        }
    }

}
