using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class CannonControl : MonoBehaviour {

	private float time = 0;
	private float maxRotationY = 45f;
	private float maxRotationX = 15f;
	private float ySpeed = 1f;
	private float xSpeed = .5f;
	private float objSpeed;
	private float startingYPos;
	public GameObject[] objs;
	System.Random rnd;
	private int seconds;
	
	// Use this for initialization
	void Start () {
		Thread.Sleep(100);
		Random.InitState(System.DateTime.Now.Millisecond);
		rnd = new System.Random();
		Debug.Log(rnd.Next(0, 99));
		startingYPos = transform.rotation.eulerAngles.y;
		seconds = rnd.Next(4, 10);
	}
	
	// Update is called once per frame
	void Update () {
		int prefabIndex = 0;
		transform.rotation = Quaternion.Euler(maxRotationX * Mathf.Sin(Time.time * xSpeed), startingYPos + maxRotationY * Mathf.Sin(Time.time * ySpeed), 0f);
		//Debug.Log(startingYPos);
		time += Time.deltaTime;
		
		if(time > seconds)
		{
				time = 0;
				seconds = rnd.Next(4, 10);
				objSpeed = rnd.Next(15, 50);
            prefabIndex = rnd.Next(1, objs.Length );
            //Debug.Log(seconds);cccccccccccccccccccccccc
            //prefabIndex = 2;
				var obj = (GameObject)Instantiate
							(objs[prefabIndex], transform.position, transform.rotation);

            obj.GetComponent<Rigidbody>().velocity = obj.transform.forward * objSpeed;
            //obj.GetComponent<Rigidbody>().AddForce(obj.transform.forward );
            obj.GetComponent<Rigidbody>().maxAngularVelocity = 10000000;
            obj.GetComponent<Rigidbody>().AddTorque(Vector3.right* 1000 * obj.GetComponent<Rigidbody>().mass);
            Destroy(obj, 13);
        }
	}
}
