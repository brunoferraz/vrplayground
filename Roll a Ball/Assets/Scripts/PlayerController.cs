using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text countText;
    public Text winText;
    public int count;
    public float speed;
    private Rigidbody rb;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        winText.gameObject.SetActive(false);
        setCountText();
    }
    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical  = Input.GetAxis("Vertical");

        Vector3 movement =  new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);        
    }
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pick_Up")){
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
            if(count>= 15){
                winText.gameObject.SetActive(true);
            }
        }
    }
    void setCountText(){
        countText.text = "Count: "+ count.ToString();
    }
}
