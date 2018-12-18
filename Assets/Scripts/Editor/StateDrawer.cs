using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(GameState))]
public class StateDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
		
		label = EditorGUI.BeginProperty(position, label, property);
		Rect contentPosition = position;
		EditorGUI.indentLevel = 0;

		contentPosition.height = 16f;

		EditorGUIUtility.labelWidth = 90f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("duration"), new GUIContent("Duration"));

		contentPosition.y += 16f;

		EditorGUI.LabelField(contentPosition,"Actors");
		contentPosition.x += 90f;
		contentPosition.width -= 90f;
		
		
		EditorGUIUtility.labelWidth = 14f;	
		contentPosition.width *= 0.25f;	


		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor1InLight"), (Screen.width < 500f) ? GUIContent.none : new GUIContent("1"));
		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor2InLight"), (Screen.width < 500f) ? GUIContent.none : new GUIContent("2"));
		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor3InLight"), (Screen.width < 500f) ? GUIContent.none : new GUIContent("3"));
		contentPosition.x += contentPosition.width;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor4InLight"), (Screen.width < 500f) ? GUIContent.none : new GUIContent("4"));
		

		contentPosition = position;
		contentPosition.y += 32f;
		contentPosition.height = 16f;

		EditorGUIUtility.labelWidth = 90f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("decor"), new GUIContent("Decor"));

		contentPosition.y += 16f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("music"), new GUIContent("Music"));



		contentPosition.y += 16f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor1Position"), new GUIContent("p1"));
		
		contentPosition.y += 16f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor2Position"), new GUIContent("p2"));

		contentPosition.y += 16f;
		EditorGUI.PropertyField(contentPosition, property.FindPropertyRelative("actor3Position"), new GUIContent("p3"));
		
	




		EditorGUI.EndProperty();
	}


	public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
		return 7 * 16f;
	}


}
