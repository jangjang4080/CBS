using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TWICE
{
	public class Quiz : MonoBehaviour 
	{
        [System.Serializable]
        public class MemberUI
        {
            public DownloadTexture downloadTexture;
            public UILabel nameLabel;
            public UILabel infoLabel;
        }

		public Camera mainCamera;
		public GameObject startButton;
        public MemberUI memberUI;

        public Dictionary<string, MemberInfo> memberDic = new Dictionary<string, MemberInfo>();

        private int currentIndex = 0;

        public void Init()
		{
            SetDataFromDB();

            SetMemberInfo(currentIndex);
        }

		public void OnStart()
		{
			GlobalAction.ButtonPushScale(startButton, 0.2f);

			Invoke("GoToQuiz", 0.2f);
		}

        public void OnNextMember()
        {
            currentIndex++;
            if (currentIndex == memberDic.Count)
                currentIndex = 0;

            SetMemberInfo(currentIndex);
        }

        public void OnKnowName()
        {
            SetMemberName(currentIndex);
        }

        void SetMemberInfo(int index)
        {
            string key = "b" + (index + 1).ToString();
            if (memberDic.ContainsKey(key))
            {
                MemberInfo m = memberDic[key];

                memberUI.downloadTexture.url = m.imageURL;
                memberUI.downloadTexture.Download();
                memberUI.nameLabel.text = "누구일까요?";
                memberUI.infoLabel.text = m.info;
            }
        }

        void SetMemberName(int index)
        {
            string key = "b" + (index + 1).ToString();
            if (memberDic.ContainsKey(key))
            {
                MemberInfo m = memberDic[key];

                memberUI.nameLabel.text = m.name;
            }
        }

		void GoToQuiz()
		{
			mainCamera.transform.localPosition = new Vector3(3000f, 0f, 0f);
		}

        public void SetDataFromDB()
        {
            TWICEDB db = new TWICEDB();
            db.Read();

            memberDic = TWICEDB.memberDic;
        }
    }	
}
