using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Vuforia
{
    public class targetData : MonoBehaviour
    {

        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonAction;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        // Use this for initialization
        void Start()
        {
		//add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);
			
//Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                // TextTargetName.GetComponent<Text>().text = name;
                ButtonAction.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


//If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if(name == "marker1"){
                    TextTargetName.GetComponent<Text>().text = "Logo Prodi TPL";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("logo"); });
                    TextDescription.GetComponent<Text>().text = "Ini merupakan re-branding logo untuk program studi Teknologi Rekayasa Perangkat Lunak. Buat yang belum tahu, jadi logo tersebut adalah buatan mahasiswa TPL yang didapat dari hasil sayembara logo. Keren bukan?";
                }



//If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

                if (name == "marker2")
                {
                    TextTargetName.GetComponent<Text>().text = "Bahasa Pemrograman";
                    ButtonAction.GetComponent<Button>().onClick.AddListener(delegate { playSound("bhs"); });
                    TextDescription.GetComponent<Text>().text = "Prodi Teknologi Rekayasa Perangkat Lunak mempelajari berbagai macam bahasa pemrograman seperti Python, Javascript, PHP, Java, dll. Kami tidak sekadar mempelajari kemudian dilupakan begitu saja, namun juga mengimplementasikannya pada real projek.";
                }
            }
        }

//function to play sound
        void playSound(string ss){
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Play();
        }
    }
}
