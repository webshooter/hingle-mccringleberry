using UnityEngine;
using System.Collections;

public class AnimateMaterial : MonoBehaviour 
{
	
	public float scrollSpeedU = 0.0f;
	public float scrollSpeedV = 0.25f;
	
	public float amplitudeU = 0.0f;
	public float amplitudeV = 0.0f;
	
	void Update()
	{
		
		float offsetU = 0.0f;
		float offsetV = 0.0f;
		
		if(amplitudeU > 0.0f) 
		{
			offsetU = amplitudeU * Mathf.Sin(scrollSpeedU * Time.time);
		} 
		else 
		{
			offsetU = Time.time * scrollSpeedU;
		}
		
		if(amplitudeV > 0.0f) 
		{
			offsetV = (amplitudeV * Mathf.Sin(scrollSpeedV * Time.time)) * -1;
		} 
		else 
		{
			offsetV = (Time.time * scrollSpeedV) * -1;
		}
		
		renderer.material.SetTextureOffset("_MainTex", new Vector2(offsetU, offsetV));
		
	}
	
}