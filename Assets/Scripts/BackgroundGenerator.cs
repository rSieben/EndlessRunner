using UnityEngine;
using System.Collections;

public class BackgroundGenerator : MonoBehaviour {

    public GameObject theSky;
    public Transform generationPoint;
    public float distanceBetween;

    private float skyWidth;
    
    // Use this for initialization
	void Start () {
        skyWidth = theSky.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + skyWidth + distanceBetween, transform.position.y, 5);
            Instantiate(theSky, transform.position, transform.rotation);
        }
	}
}
