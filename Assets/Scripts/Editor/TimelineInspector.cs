using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TimeLine))]
public class TimeLineInspector : Editor 
{
    public override void OnInspectorGUI()
    {
		serializedObject.Update();
        TimeLine myTarget = (TimeLine)target;

		SerializedProperty list = serializedObject.FindProperty("states");



		float time = 0;

		for (int i = 0; i < list.arraySize; i++) {

			EditorGUILayout.BeginVertical(GUI.skin.box);


			EditorGUILayout.LabelField("Time: " + time.ToString());
			


			if(i != 0 && i != list.arraySize - 1){
				
				EditorGUILayout.BeginHorizontal(GUI.skin.box);

				if(GUILayout.Button("x",  GUILayout.Width(20), GUILayout.Height(20))){
					list.DeleteArrayElementAtIndex(i);
				}
				if(GUILayout.Button("▲",  GUILayout.Width(20), GUILayout.Height(20))){

					list.MoveArrayElement(i, i - 1);

				}
				if(GUILayout.Button("▼",  GUILayout.Width(20), GUILayout.Height(20))){
					list.MoveArrayElement(i, i + 1);
				}
				
				EditorGUILayout.EndHorizontal();

			}

			


			EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
			



			EditorGUILayout.EndVertical();

			time += (float)list.GetArrayElementAtIndex(i).FindPropertyRelative("duration").floatValue;

		}


		if(GUILayout.Button("+")){
				list.InsertArrayElementAtIndex(list.arraySize);
		}


		serializedObject.ApplyModifiedProperties();
    }
}