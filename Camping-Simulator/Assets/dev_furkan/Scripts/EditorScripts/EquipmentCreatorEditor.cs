using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EquipmentScriptableObject))]
public class EquipmentCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        EquipmentScriptableObject equipment = (EquipmentScriptableObject)target;

        EditorGUI.BeginChangeCheck();

        equipment.equipmentName = EditorGUILayout.TextField("Equipment Name", equipment.equipmentName);
        equipment.mobility = EditorGUILayout.FloatField("Mobility", equipment.mobility);
        equipment.coldResistance = EditorGUILayout.IntField("Cold Resistance", equipment.coldResistance);
        // Add GUI elements for additional properties

        if (EditorGUI.EndChangeCheck())
        {
            // If changes are made in the Editor, mark the asset as dirty to save changes
            EditorUtility.SetDirty(equipment);
        }

        if (GUILayout.Button("Create Prefab"))
        {
            CreateEquipmentPrefab(equipment);
        }
    }

    private void CreateEquipmentPrefab(EquipmentScriptableObject equipment)
    {
        // Instantiate a prefab with a specific name and set its properties
        GameObject equipmentPrefab = new GameObject(equipment.equipmentName);
        equipmentPrefab.AddComponent<Equipment>().equipmentData = equipment;

        // Save the prefab
        string path = "Assets/Prefabs/Equipment";
        if (!AssetDatabase.IsValidFolder(path))
        {
            AssetDatabase.CreateFolder("Assets", "Prefabs");
        }

        path = AssetDatabase.GenerateUniqueAssetPath(path + "/" + equipment.equipmentName + ".prefab");
        PrefabUtility.SaveAsPrefabAsset(equipmentPrefab, path);

        // Destroy the temporary GameObject
        DestroyImmediate(equipmentPrefab);

        // Refresh the AssetDatabase to ensure the new prefab is recognized
        AssetDatabase.Refresh();
    }
}
