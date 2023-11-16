using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    Vector3 preMousePos;
    Vector3 mouseDelta;
    float speed = 200f;

    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        swipe();
        //Drag();
         //automatically move to the target position
            if(transform.rotation != target.transform.rotation){
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        
    }

    void Drag(){
        if(Input.GetMouseButton(1)){
           mouseDelta = Input.mousePosition - preMousePos;
           mouseDelta *= 0.6f; //reduction of rotation speed
           transform.rotation = Quaternion.Euler(mouseDelta.y, -mouseDelta.x, 0) * transform.rotation;

        }
        else{
             //automatically move to the target position
            if(transform.rotation != target.transform.rotation){
            var step = speed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.transform.rotation, step);
            }
        }
        preMousePos = Input.mousePosition;
    }

    void swipe(){
        if(Input.GetMouseButtonDown(1)){
            //Get the 2D position of the first mouse click
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        }

        if(Input.GetMouseButtonUp(1)){
            //get the 2D position pf the second mouse click
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            //create a vector from the first and second click positions
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - secondPressPos.y);
            //normlize the 2d vector
            currentSwipe.Normalize();
            if(LeftSwipe(currentSwipe)){
                target.transform.Rotate(0,90,0, Space.World);
            }
            else if(RightSwipe(currentSwipe)){
                target.transform.Rotate(0,-90,0, Space.World);
            }
            else if(UpLeftSwipe(currentSwipe)){
                target.transform.Rotate(90,0,0, Space.World);
            }
            else if(UpRightSwipe(currentSwipe)){
                target.transform.Rotate(0,0,-90, Space.World);
            }
            else if(DownLeftSwipe(currentSwipe)){
                target.transform.Rotate(0,0,90, Space.World);
            }else if(DownRightSwipe(currentSwipe)){
                target.transform.Rotate(-90,0,0, Space.World);
            }
        }
    }

    bool LeftSwipe(Vector2 Swipe){
        //This is true if the swipe is moving in the negative direction or not moved up or down much
        return currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f; 
    }
    bool RightSwipe(Vector2 Swipe){
        //This is true if the swipe is moving in the postive direction or not moved up or down much
        return currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f; 
    }
    bool UpLeftSwipe(Vector2 Swipe){
        return currentSwipe.y > 0f && currentSwipe.x < 0f;
    }
    bool UpRightSwipe(Vector2 Swipe){
        return currentSwipe.y < 0f && currentSwipe.x > 0f;
    }
    bool DownLeftSwipe(Vector2 Swipe){
        return currentSwipe.y < 0f && currentSwipe.x < 0f;
    }
    bool DownRightSwipe(Vector2 Swipe){
        return currentSwipe.y < 0f && currentSwipe.x > 0f;
    }

}
