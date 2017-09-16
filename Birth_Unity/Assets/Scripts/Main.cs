using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWICE
{
	public class Main : MonoBehaviour 
	{
		void Start () 
		{
			Quiz quiz = GameObject.FindObjectOfType<Quiz>();
			if (quiz != null)
			{
				quiz.Init();
			}
		}
		
		void Update () 
		{
			
		}
	}
}
