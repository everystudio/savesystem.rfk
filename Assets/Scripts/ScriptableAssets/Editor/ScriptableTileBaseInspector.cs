using UnityEngine;
using System.Collections;
using UnityEditor;

namespace anogame
{
    [CustomEditor(typeof(ScriptableTileBase), true)]
    public class ScriptableTileBaseInspector : Editor
    {
        //private static ScriptableAsset currentTarget;
        private string currentGUID;

        public override void OnInspectorGUI()
        {
            if (string.IsNullOrEmpty(currentGUID))
            {
                currentGUID = $"GUID: {((IReferenceableAsset)target).GetGuid()}";
            }

            EditorGUILayout.TextArea(currentGUID, EditorStyles.centeredGreyMiniLabel);

            base.DrawDefaultInspector();
        }
    }
}
