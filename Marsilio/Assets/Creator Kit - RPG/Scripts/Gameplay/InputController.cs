using RPGM.Core;
using RPGM.Gameplay;
using UnityEngine;

namespace RPGM.UI
{
    /// <summary>
    /// Sends user input to the correct control systems.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        public float stepSize = 0.1f;
        GameModel model = Schedule.GetModel<GameModel>();

        public enum State
        {
            CharacterControl,
            DialogControl,
            Pause
        }

        State state;

        public void ChangeState(State state) => this.state = state;

        void Update()
        {
            switch (state)
            {
                case State.CharacterControl:
                    CharacterControl();
                    break;
                case State.DialogControl:
                    DialogControl();
                    break;
            }
        }

        void DialogControl()
        {
            model.player.nextMoveCommand = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                model.dialog.FocusButton(-1);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                model.dialog.FocusButton(+1);
            if (Input.GetKeyDown(KeyCode.Space))
                model.dialog.SelectActiveButton();
        }

        void CharacterControl()
        {
            /*if (Input.GetKey(KeyCode.UpArrow))
                model.player.nextMoveCommand = Vector3.up * stepSize;
            else if (Input.GetKey(KeyCode.DownArrow))
                model.player.nextMoveCommand = Vector3.down * stepSize;
            else if (Input.GetKey(KeyCode.LeftArrow))
                model.player.nextMoveCommand = Vector3.left * stepSize;
            else if (Input.GetKey(KeyCode.RightArrow))
                model.player.nextMoveCommand = Vector3.right * stepSize;
            else
                model.player.nextMoveCommand = Vector3.zero;*/
            Vector3 direction = Vector3.zero;
            if (Input.anyKey)
            {
                if (Input.GetKey(KeyCode.W))
                    direction.y = 1;
                if (Input.GetKey(KeyCode.A))
                    direction.x = -1;
                if (Input.GetKey(KeyCode.S))
                    direction.y = -1;
                if (Input.GetKey(KeyCode.D))
                    direction.x = 1;
            }
            else direction = Vector3.zero;
            model.player.nextMoveCommand = direction.normalized*stepSize;
        }
    }
}