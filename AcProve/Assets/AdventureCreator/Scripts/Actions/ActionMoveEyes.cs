//using Rainbow.Gameplay;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;
//using Cysharp.Threading.Tasks;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{
    [System.Serializable]
    public class ActionMoveEyes : Action
    {
        private const string paramName = "_PupilOffset";
        private const string defaultMaterialName = "Eyes";
        private const string errorMessage = "Couldn't access material";

        private const string targetParamLabel = "Target:";
        private const string newVec3Label = "Value to set:";
        private const string interpTimeLabel = "Interpolation time:";
        private const string materialNameLabel = "Material name:";

        // Declare properties here
        public override ActionCategory Category => ActionCategory.RainbowHigh;
        public override string Title => "Move eyes";
        public override string Description => "Interpolate eye material position and size";


        // Declare variables here
        public int parameterID = -1;
        public int constantID = 0;
        public Vector3 targetVec3Value;
        public float interpolationTime;
        public GameObject target;
        public string materialName;
        private Renderer[] runtimeTargetRenderer;

       // public PlayerStatusUI playerStatusUI;

        public override void AssignValues(List<ActionParameter> parameters)
        {
            runtimeTargetRenderer = new Renderer[1];

            var result = AssignFile(parameters, parameterID, constantID, target);
            if (result == null)
            {
                return;
            }

            runtimeTargetRenderer[0] = result.GetComponent<Renderer>();
            if (runtimeTargetRenderer[0] == null)
            {
                runtimeTargetRenderer = result.transform.GetComponentsInChildren<Renderer>();
            }
        }

        public override float Run()
        {
            materialName = (materialName.Length > 0) ? materialName : defaultMaterialName;
            if (runtimeTargetRenderer[0] != null)
            {
                foreach (var renderer in runtimeTargetRenderer)
                {
                    foreach (var mat in renderer.materials)
                    {
                        if (mat.name.Contains(materialName))
                        {
                            InterpolateVec2(mat);
                        }
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

            targetVec3Value = EditorGUILayout.Vector3Field(newVec3Label, targetVec3Value);
            interpolationTime = EditorGUILayout.FloatField(interpTimeLabel, interpolationTime);

            materialName = EditorGUILayout.TextField(materialNameLabel, materialName);

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

        private void InterpolateVec2(Material mat)
        {
            Vector4 finalVec4Value = mat.GetVector(paramName);
            finalVec4Value.x = targetVec3Value.x;
            finalVec4Value.y = targetVec3Value.y;
            finalVec4Value.z = 1-targetVec3Value.z;

           // mat.DOVector(finalVec4Value, paramName, interpolationTime);
        }

    }

}