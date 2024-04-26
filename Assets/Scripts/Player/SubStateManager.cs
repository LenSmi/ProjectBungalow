using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public static class SubStateManager
    {
        public static GameConstants.PlayerStates currentSubState = GameConstants.PlayerStates.IDLE;

        public static void ChangePlayerState(GameConstants.PlayerStates newState)
        {
            switch (currentSubState)
            {
                case GameConstants.PlayerStates.IDLE:
                    break;
                case GameConstants.PlayerStates.MOVING:
                    break;
                case GameConstants.PlayerStates.MINNING:
                    break;
            }

            switch (newState)
            {
                case GameConstants.PlayerStates.IDLE:
                    break;
                case GameConstants.PlayerStates.MOVING:
                    break;
                case GameConstants.PlayerStates.MINNING:
                    break;
            }

            currentSubState = newState;

        }
    }
