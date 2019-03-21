using UnityEngine;
using UnityEditor;

public class PrefabTool : EditorWindow
{
    public bool menu1;
    public enum menuOption { menu1, menu2, nomenu };
    public static menuOption optionChosen;
    public static Color newColor;
    public int R;
    public int G;
    public int B;
    public int A;
    public string customPrefabName;

    [MenuItem("Prefab Tool/Create Prefab!")]
    static void CreatePrefab()
    {
        optionChosen = menuOption.nomenu;
        GameObject[] selectedGameObjects = Selection.gameObjects;

        foreach (GameObject gameObject in selectedGameObjects)
        {
            string objectsPath = "Assets/" + gameObject.name + ".prefab";
            Debug.Log("Custom Color Chosen");
            PrefabTool window = ScriptableObject.CreateInstance<PrefabTool>();
            window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 300);
            window.ShowPopup();
            window.Show();
            window.Focus();
            window.Repaint();
            
        }
    }
    
    static bool DisableMenu()
    {
        return Selection.activeGameObject != null;
    }

    static void MakePrefab(GameObject obj, string objectsPath, string newMaterialName)
    {
        Object prefab = PrefabUtility.CreatePrefab(objectsPath, obj);
        Material material = new Material(Shader.Find("Specular"));
        material = obj.GetComponent<Renderer>().material;
        AssetDatabase.CreateAsset(material, "Assets/" + newMaterialName + ".mat");
        PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }

    void OnGUI()
    {
        if (GUILayout.Button("Custom Color"))
        {
            optionChosen = menuOption.menu1;
        }
        if (GUILayout.Button("Preset Color"))
        {
            optionChosen = menuOption.menu2;
        }
        if (optionChosen == menuOption.menu1)
        {

            EditorGUILayout.LabelField("Pick the RGBA Values of your color:", EditorStyles.wordWrappedLabel);
            GUILayout.Space(100);

            customPrefabName = EditorGUILayout.TextField("Name your Prefab: ", customPrefabName);
            newColor.r = R = EditorGUILayout.IntField("R Value: ", R);
            newColor.g = G = EditorGUILayout.IntField("G Value: ", G);
            newColor.b = B = EditorGUILayout.IntField("B Value: ", B);
            newColor.a = A = EditorGUILayout.IntField("A Value: ", A);

            GameObject[] selectedGameObjects = Selection.gameObjects;

            foreach (GameObject gameObject in selectedGameObjects)
            {
                if (GUILayout.Button("Make the Prefab!!"))
                {
                    gameObject.GetComponent<Renderer>().material.color = newColor;
                    string objectsPath = "Assets/" + customPrefabName + ".prefab";
                    MakePrefab(gameObject, objectsPath, customPrefabName);
                    this.Close();
                }
            }
        }
        else if (optionChosen == menuOption.menu2)
        {
            GameObject[] selectedGameObjects = Selection.gameObjects;

            customPrefabName = EditorGUILayout.TextField("Name your Prefab: ", customPrefabName);

            foreach (GameObject gameObject in selectedGameObjects)
            {
                if (GUILayout.Button("Red"))
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.red;
                    string objectsPath = "Assets/" + customPrefabName + ".prefab";
                    MakePrefab(gameObject, objectsPath, customPrefabName);
                    this.Close();
                }
                if (GUILayout.Button("Blue"))
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.blue;
                    string objectsPath = "Assets/" + customPrefabName + ".prefab";
                    MakePrefab(gameObject, objectsPath, customPrefabName);
                    this.Close();
                }
                if (GUILayout.Button("Green"))
                {
                    gameObject.GetComponent<Renderer>().material.color = Color.green;
                    string objectsPath = "Assets/" + customPrefabName + ".prefab";
                    MakePrefab(gameObject, objectsPath, customPrefabName);
                    this.Close();
                }
            }
        }
        
        if (GUILayout.Button("Exit"))
        {
            this.Close();
        }
    }
}