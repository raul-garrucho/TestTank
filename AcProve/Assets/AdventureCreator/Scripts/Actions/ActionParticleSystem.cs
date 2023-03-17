/*
 *
 *	Adventure Creator
 *	by Chris Burton, 2013-2021
 *	
 *	"ActionTemplate.cs"
 * 
 *	This is a blank action template.
 * 
 */

using UnityEngine;
using System.Collections.Generic;

using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace AC
{

    [System.Serializable]
    public class ActionParticleSystem : Action
    {
        private const int DELAY_MARGIN = 500;

        public enum ParticleSystemActions { TurnOn, TurnOff }

        // Declare properties here
        public override ActionCategory Category { get { return ActionCategory.RainbowHigh; } }
        public override string Title { get { return "Particle System"; } }
        public override string Description { get { return "This is a blank Action template."; } }


        // Declare variables here

        public int parameterID = -1;
        public int constantID = 0;

        public ParticleSystem particleSystem;
        public ParticleSystemActions action = ParticleSystemActions.TurnOn;

        public bool loop = false;
        public bool waitForEnd = false;
        public bool destroyAfterFinish = false;

        public Transform parent = null;
        public bool setParentPosition = false;
        public bool setParentRotation = false;

        private ParticleSystem runtimeParticleSystem = null;
        private Transform runtimeParent = null;

        private bool waitingForEnd = false;

        public override void AssignValues(List<ActionParameter> parameters)
        {
            runtimeParent = AssignFile(parameters, parameterID, constantID, parent);
        }

        public override float Run()
        {
            if (!isRunning)
            {
                InstantiateParticleSystem();

                ParticleSystem.MainModule mainModule = runtimeParticleSystem.main;
                mainModule.loop = loop;

                if (destroyAfterFinish)
                {
                    mainModule.stopAction = ParticleSystemStopAction.Destroy;
                }
                else
                {
                    mainModule.stopAction = ParticleSystemStopAction.Disable;
                }

                switch (action)
                {
                    case ParticleSystemActions.TurnOn:
                        if (waitForEnd)
                        {
                            TurnOn();
                            WaitForEnd(TurnOff);
                        }
                        else
                        {
                            TurnOn();
                        }
                        break;
                    case ParticleSystemActions.TurnOff:
                        TurnOff();
                        break;
                }

                if(!waitForEnd && !loop && destroyAfterFinish)
                {
                    Destroy(runtimeParticleSystem.gameObject, mainModule.duration);
                }
            }

            if (waitingForEnd)
            {
                isRunning = true;
                return 1f;
            }
            else
            {
                isRunning = false;
                return 0f;
            }
        }

        public override void Skip()
        {
            Run();
        }


#if UNITY_EDITOR

        public override void ShowGUI(List<ActionParameter> parameters)
        {
            particleSystem = (ParticleSystem)CustomGUILayout.ObjectField<ParticleSystem>("Particle System: ", particleSystem, false);
            action = (ParticleSystemActions)EditorGUILayout.EnumPopup("Action to execute: ", action);

            if (action == ParticleSystemActions.TurnOff)
            {
                return;
            }

            waitForEnd = EditorGUILayout.Toggle("Wait For End: ", waitForEnd);

            if (!waitForEnd)
            {
                loop = EditorGUILayout.Toggle("Loop: ", loop);
            }

            if (!loop || waitForEnd)
            {
                destroyAfterFinish = EditorGUILayout.Toggle("Destroy after finish: ", destroyAfterFinish);
            }

            parameterID = ChooseParameterGUI("Parent:", parameters, parameterID, ParameterType.GameObject);
            if (parameterID >= 0)
            {
                constantID = 0;
                parent = null;
            }
            else
            {
                parent = (Transform)EditorGUILayout.ObjectField("Parent: ", parent, typeof(Transform),true);

                constantID = FieldToID(parent, constantID);
                parent = IDToField(parent, constantID, false);
            }

            if (parent != null)
            {
                setParentPosition = EditorGUILayout.Toggle("Set Parent Position: ", setParentPosition);
                setParentRotation = EditorGUILayout.Toggle("Set Parent Rotation: ", setParentRotation);
            }
        }

#endif

        private void InstantiateParticleSystem()
        {
            runtimeParticleSystem = Instantiate(particleSystem);
            if (runtimeParent != null)
            {
                runtimeParticleSystem.transform.SetParent(runtimeParent.transform);
            }
            else
            {
                return;
            }

            if (setParentPosition)
            {
                runtimeParticleSystem.transform.localPosition = Vector3.zero;
            }
            if (setParentRotation)
            {
                runtimeParticleSystem.transform.localRotation = Quaternion.identity;
            }
        }

        private void TurnOn()
        {
            if (runtimeParticleSystem != null)
            {
                runtimeParticleSystem.gameObject.SetActive(true);
                runtimeParticleSystem.Play();
            }
        }

        private void TurnOff()
        {
            if (runtimeParticleSystem != null)
            {
                runtimeParticleSystem.Stop();
            }
        }

        private async void WaitForEnd(UnityAction callback = null)
        {
            waitingForEnd = true;
            ParticleSystem.MainModule mainModule = runtimeParticleSystem.main;
            
            if(callback != null)
            {
                callback.Invoke();
            }

            waitingForEnd = false;

            if (destroyAfterFinish)
            {
                Destroy(runtimeParticleSystem.gameObject);
            }
        }
    }
}