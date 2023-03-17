
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{
    [System.Serializable]
    public class ActionSetMaterialBool : Action
    {
        private const string defaultParamName = "_MainMenuSwitch";
        private const string errorMessage = "Couldn't access material";

        private const string targetParamLabel = "Object with material:";
        private const string boolValueLabel = "Value to set:";
        private const string materialNameLabel = "Material name:";
        private const string materialPropertyLabel = "Material property name:";

        // Declare properties here
        public override ActionCategory Category => ActionCategory.RainbowHigh;
        public override string Title => "Set Material Bool";
        public override string Description => "Sets the boolean value in a material instance";


        // Declare variables here
        public int parameterID = -1;
        public int constantID = 0;
        public bool newValue;
        public GameObject target;
        public string materialName;
        public string materialPropertyName;
        private Renderer runtimeTargetRenderer;

        //public PlayerStatusUI playerStatusUI;

        public override void AssignValues(List<ActionParameter> parameters)
        {
            var result = AssignFile(parameters, parameterID, constantID, target);

            if (result == null)
            {
                return;
            }

            runtimeTargetRenderer = result.GetComponent<Renderer>();
        }

        public override float Run()
        {
            if (runtimeTargetRenderer)
            {
                string param = (materialPropertyName.Length > 0) ? materialPropertyName : defaultParamName;
                foreach (var mat in runtimeTargetRenderer.materials)
                {
                    if (mat.name.Contains(materialName))
                    {
                        mat.SetFloat(param, newValue ? 1 : 0);
                    }
                }
            }
            else
            {
                Debug.LogError(errorMessage);
            }

            return 0f;
        }

        public override void Skip()
        {
            Run();
        }


#if UNITY_EDITOR

        public override void ShowGUI(List<ActionParameter> parameters)
        {
            newValue = EditorGUILayout.Toggle(boolValueLabel, newValue);

            materialName = EditorGUILayout.TextField(materialNameLabel, materialName);
            materialPropertyName = EditorGUILayout.TextField(materialPropertyLabel, materialPropertyName);

            parameterID = Action.ChooseParameterGUI(targetParamLabel, parameters, parameterID, ParameterType.GameObject);
            if (parameterID >= 0)
            {
                constantID = 0;
                target = null;
            }
            else
            {
                target = (GameObject)EditorGUILayout.ObjectField(targetParamLabel, target, typeof(GameObject), true);

                constantID = FieldToID(target, constantID);
                target = IDToField(target, constantID, false);
            }
        }
#endif

    }

}