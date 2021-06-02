/*****
 * Author: Akram Taghavi-Burris
 * Date Created: NA - Copied from Playground 
 * Last Updated: May 31, 2021 - Addtions only
 * Description: Custom Editor for the Condition Collison Inspector
 * Project: 3D Playground - a drag and drop framework for 3d game development derived from Unity's own 2D Playground framework.
 ****/


using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionCollision))]
public class ConditionCollisionInspector : ConditionInspectorBase
{
	private string explanation = "Use this script to perform an action when this GameObject collides with another.";

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		chosenTag = serializedObject.FindProperty("filterTag").stringValue;

		

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		DrawTagsGroup();

		GUILayout.Space(10);
		DrawActionLists();
		//ADDED: include delete property in inspector
		EditorGUILayout.PropertyField(serializedObject.FindProperty("destroyOnCollision"));

		//ADDED: include debug property in inspector
		EditorGUILayout.PropertyField(serializedObject.FindProperty("debugCode"));
		
		//CheckIfTrigger(false); checks for collider (has been turned off)

		if (GUI.changed)
		{
			serializedObject.FindProperty("filterTag").stringValue = chosenTag;
			serializedObject.ApplyModifiedProperties();
		}
	}
}