using ToolbarExtension;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class CompileDllToolbar
    {
        private static readonly GUIContent s_BuildReloadHotfixButtonGUIContent = new GUIContent("Reload", "Compile And Reload ET.Hotfix Dll When Playing.");
        private static readonly GUIContent s_BuildHotfixModelButtonGUIContent = new GUIContent("Compile", "Compile All ET Dll.");

        [Toolbar(OnGUISide.Left, 0)]
        static void OnToolbarGUI()
        {
            EditorGUI.BeginDisabledGroup(!Application.isPlaying);
            {
                if (GUILayout.Button(s_BuildReloadHotfixButtonGUIContent))
                {
                    GlobalConfig globalConfig = Resources.Load<GlobalConfig>("GlobalConfig");
                    if (!globalConfig.EnableDll)
                    {
                        Debug.LogError("Plaese reload after open EnableDll!");
                        return;
                    }
                    AssemblyTool.DoCompile();
                    CodeLoader.Instance.Reload();
                    Debug.Log("reload success!");
                }
            }
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button(s_BuildHotfixModelButtonGUIContent))
            {
                AssemblyTool.DoCompile();
                Debug.Log("compile success!");
            }
        }
    }
}