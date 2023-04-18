using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMSGameplay : MonoBehaviour
{
    
        public enum State
        {
            None,
            Start,
            OnePlayer,
            TwoPlayers,
            Exit
        }

        public Action OnExitNone = null;
        public Action OnExitStart = null;
        public Action OnExitOnePlayer = null;
        public Action OnExitTwoPlayers = null;
        public Action OnExitExit = null;

        public Action OnEnterStart = null;
        public Action OnEnterOnePlayer = null;
        public Action OnEnterTwoPlayers = null;
        public Action OnEnterExit = null;

        private State currentState = State.None;

        public void ChangeToStart()
        {
            ChangeState(State.Start);
        }
        public void ChangeToOnePlayer()
        {
            ChangeState(State.OnePlayer);
        }

        public void ChangeToTwoPlayer()
        {
            ChangeState(State.TwoPlayers);
        }

        public void ChangeToExit()
        {
            ChangeState(State.Exit);
        }

        private void ChangeState(State state)
        {
            OnExitState();

            currentState = state;

            OnEnterState();
        }

        private void OnExitState()
        {
            switch (currentState)
            {
                case State.None:
                    ExitNone();
                    break;
                case State.Start:
                    ExitStart();
                    break;
                case State.OnePlayer:
                    ExitOnePlayer();
                    break;
                case State.TwoPlayers:
                    ExitTwoPlayers();
                    break;
                case State.Exit:
                    ExitExit();
                    break;
            }
        }

        private void OnEnterState()
        {
            switch (currentState)
            {
                case State.Start:
                    EnterStart();
                    break;
                case State.OnePlayer:
                    EnterOnePlayer();
                    break;
                case State.TwoPlayers:
                    EnterTwoPlayers();
                    break;
                case State.Exit:
                    EnterExit();
                    break;
            }
        }

        private void ExitNone()
        {
            OnExitNone?.Invoke();
        }
        private void ExitStart()
        {
            OnExitStart?.Invoke();
        }
        private void ExitOnePlayer()
        {
            OnExitOnePlayer?.Invoke();
        }

        private void ExitTwoPlayers()
        {
            OnExitTwoPlayers?.Invoke();
        }

        private void ExitExit()
        {
            OnExitExit?.Invoke();
        }
        private void EnterStart()
        {
            OnEnterStart?.Invoke();
        }

        private void EnterOnePlayer()
        {
            OnEnterOnePlayer?.Invoke();
        }

        private void EnterTwoPlayers()
        {
            OnEnterTwoPlayers?.Invoke();
        }

        private void EnterExit()
        {
            OnEnterExit?.Invoke();
        }
    
}
