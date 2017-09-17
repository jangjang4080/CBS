using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWICE
{
	public class Main : MonoBehaviour 
	{
		public string dbIPAdress = "";

		void Start () 
		{
			Env.dbIPAdress = dbIPAdress;

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
