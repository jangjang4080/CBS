using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWICE
{
	public class Quiz : MonoBehaviour 
	{
		public Camera mainCamera;
		public GameObject startButton;

		public void Init()
		{

		}

		public void OnStart()
		{
			GlobalAction.ButtonPushScale(startButton, 0.2f);

			Invoke("GoToQuiz", 0.2f);
		}

		void GoToQuiz()
		{
			mainCamera.transform.localPosition = new Vector3(3000f, 0f, 0f);
		}
	}	
}
