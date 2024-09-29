using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    //obstacle movements
   
    public float moveSpeed = 5;
    
    void Update()
    {
        transform.position += Vector3.left * moveSpeed * SpeedManager.Instance.moveSpeed *Time.deltaTime;
        
      
       
    }
}
