using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class InputStyles : MonoBehaviour
{
    public GameObject particlesSpawnEffect;
    //public bool colorEffect;
    public enum InteractionMode { MOUSE, TOUCH}
    public InteractionMode interactionMode;

    void InputController()
    {
        switch (interactionMode)
        {
            case InteractionMode.MOUSE:
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.gameObject)
                        {
                            DamageHit(hit);
                        }
                    }
                }
                break;

            case InteractionMode.TOUCH:
                if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);

                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.collider.gameObject)
                        {
                            DamageHit(hit);
                        }
                    }
                }
                break;
        }     
    }

    private void DamageHit(RaycastHit hit)
    {
        //var newParticle = Instantiate(particlesSpawnEffect, hit.point, Quaternion.identity);
        Instantiate(particlesSpawnEffect, hit.point, Quaternion.identity);
        hit.collider.gameObject.GetComponent<TakeDamage>().TakeDamages(1f);

        //if (colorEffect)
        //{
        //    newParticle.GetComponent<SpriteRenderer>().color = hit.collider.gameObject.GetComponent<ColorHit>().colorImg;
        //} else
        //{
        //    newParticle.GetComponent<SpriteRenderer>().color = Color.green;
        //}
    }

    void Update()
    {
        InputController();
    }

    #region UnityEditor
#if UNITY_EDITOR
    [CustomEditor(typeof(InputStyles))]
    public class EnumTabsExampleEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField(" ");

            InputStyles inputStyles = (InputStyles)target;

            inputStyles.particlesSpawnEffect = (GameObject)EditorGUILayout.ObjectField
                ("Particle Effect", inputStyles.particlesSpawnEffect, typeof(GameObject), true);
            EditorGUILayout.LabelField(" ");

            inputStyles.interactionMode = (InteractionMode)GUILayout.Toolbar
                ((int)inputStyles.interactionMode, new string[] { "MOUSE", "TOUCH"}, GUILayout.Height(50));

            switch (inputStyles.interactionMode)
            {
                case InteractionMode.MOUSE:
                    //EditorGUILayout.LabelField("Взаимодействие мышкой");
                    EditorGUILayout.LabelField("");
                    SetIconName("Mouse");
                    break;

                case InteractionMode.TOUCH:
                    //EditorGUILayout.LabelField("Взаимодействие тачом");
                    EditorGUILayout.LabelField(" ");
                    SetIconName("Touch");
                    break;
            }
        }

        public static void SetIconName(string m_iconName)
        {
            string iconPath = "Assets/WALL_GAMES/Editor/InteractionMode/" + m_iconName + ".png";
            Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(iconPath);
            GUILayout.BeginHorizontal();
            EditorGUILayout.Space();
            GUILayout.Label(" ", GUILayout.Height(200), GUILayout.Width(200));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
            EditorGUILayout.Space();
            GUILayout.EndHorizontal();
        }
    }
#endif
    #endregion
}


