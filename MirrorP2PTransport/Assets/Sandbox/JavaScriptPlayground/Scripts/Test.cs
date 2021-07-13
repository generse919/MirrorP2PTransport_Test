﻿using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;

namespace Sandbox.JavaScriptPlayground
{
    public class Test : MonoBehaviour
    {
        [DllImport("__Internal")]
        private static extern void HelloWorld();

        void OnGUI()
        {
            float margin = Screen.width / 100f;
            GUILayout.BeginArea(new Rect(margin, margin, Screen.width - margin * 2f, Screen.height - margin * 2f));

            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            this.OnButtonGUI("test", () => { HelloWorld(); });

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();

            GUILayout.EndArea();
        }

        void OnButtonGUI(string buttonName, UnityAction action)
        {
            float    mingHeight  = Screen.height / 20f;
            float    margin      = Screen.width / 100f;
            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

            if (GUILayout.Button(buttonName, buttonStyle, GUILayout.MinWidth(Screen.width - margin * 2f), GUILayout.MinHeight(mingHeight)))
            {
                action?.Invoke();
            }
        }
    }
}
