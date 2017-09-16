using UnityEngine;
using System.Collections;
using System.IO;

namespace  TWICE
{
    public class DownloadTexture : MonoBehaviour
    {
        public UITexture texture;
        public bool autoStart = false;
        public string url = "";

        public void Download()
        {
            StartCoroutine(StartDownload());
        }

        private IEnumerator StartDownload()
        {
            Texture2D tex = new Texture2D((int)texture.width, (int)texture.height, TextureFormat.ARGB32, false);
            WWW www = new WWW(url);
            yield return www;
            www.LoadImageIntoTexture(tex);
            texture.mainTexture = tex;
        }

        void Start()
        {
            if (autoStart)
            {
                StartCoroutine(StartDownload());
            }
        }
    }   
}