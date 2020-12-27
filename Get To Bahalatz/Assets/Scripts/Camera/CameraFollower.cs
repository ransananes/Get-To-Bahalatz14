using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

public class CameraFollower : MonoBehaviour
{

	//offset from the viewport center to fix damping
	public float m_DampTime = 10f;
	public Transform m_Target;
	public Transform background;
	public float m_XOffset = 0;
	public float m_YOffset = 0;
	
	private float margin = 0.1f;


	void Update()
	{
		if (m_Target)
		{
			float targetX = m_Target.position.x + m_XOffset;

			if (Mathf.Abs(transform.position.x - targetX) > margin)
				targetX = Mathf.Lerp(transform.position.x, targetX, 1 / m_DampTime * Time.deltaTime);


			transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
		}
		background.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
}