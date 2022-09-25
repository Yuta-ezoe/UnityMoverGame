using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMover : MonoBehaviour
{
	[SerializeField]
	private float speed = 5.0f;

	[SerializeField]
	private Material originalColor;


	private bool _isMoveAllow=false;
	private bool _isInstansiate = false;

	private float vecX;

	public bool IsMoveAllow
	{
        set{

			this._isMoveAllow = value;

		}

	}

	public bool IsInstansiate
	{
		set
		{

			this._isInstansiate = value;

		}

	}



	// Update is called once per frame
	void Update()
	{


		MovingObject();


		if (_isInstansiate)
        {
			vecX = Random.Range(0f, 10.0f);
			Instantiate(gameObject, new Vector3(-8, vecX, 0), Quaternion.identity);
			this._isInstansiate = false;

		}

	}

	private void MovingObject()
    {

		if (_isMoveAllow)
		{

			GetComponent<Renderer>().material.color = Color.red;

			if (Input.GetKey("up"))
			{
				transform.position += transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey("down"))
			{
				transform.position -= transform.forward * speed * Time.deltaTime;
			}
			if (Input.GetKey("right"))
			{
				transform.position += transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKey("left"))
			{
				transform.position -= transform.right * speed * Time.deltaTime;
			}


		}
		else
		{
			GetComponent<Renderer>().material.color = originalColor.color;
		}

	}

}
