using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    CapsuleCollider playerCol;
    float originalHeight;
    public float reducedHeight;
    // Start is called before the first frame update
    void Start()
    {
        playerCol = GetComponent<CapsuleCollider>();
        originalHeight = playerCol.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Crouching script.
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouch();
        else if(Input.GetKeyUp(KeyCode.LeftControl)) 
            GoUp();
    }


    // Script to reduce height.
    void crouch()
    {
        playerCol.height = reducedHeight; 
    }

    // Script to reset height.
    void GoUp()
    {
        playerCol.height = originalHeight; 
    }

}
