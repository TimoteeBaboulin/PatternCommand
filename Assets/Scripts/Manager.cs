using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using UnityEngine;

public class Manager : MonoBehaviour{
    public static event Action OnFuseChange;
    public List<Cube> CurrentCube = new();

    [SerializeField] private float _coroutineDelay = 0.2f;
    private readonly Stack<Command> _commandStack = new();
    private bool _canInput = true;
    private bool _fusing;

    private void Update(){
        if (!_canInput) return;

        if (Input.GetKeyDown(KeyCode.F)){
            _fusing = !_fusing;
            OnFuseChange?.Invoke();
        }

        if (Input.GetButtonDown("Fire1")){
            if (!_fusing) ChangeCube(PickCube());
            else AddCube(PickCube());
        }


        if (Input.GetButtonDown("Fire2"))
            KillCube(PickCube());

        if (Input.GetKeyDown(KeyCode.R)){
            StartCoroutine(ResetCoroutine());
            return;
        }


        if (Input.GetButtonDown("Jump") && _commandStack.Count > 0)
            _commandStack.Pop().Undo();


        if (CurrentCube == null) return;

        //Movement
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            var command = new CommandPropagate<CommandRight>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            var command = new CommandPropagate<CommandLeft>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)){
            var command = new CommandPropagate<CommandForward>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)){
            var command = new CommandPropagate<CommandBackward>(this);
            command.Do();
            _commandStack.Push(command);
        }

        //Duplicate and move
        if (Input.GetKeyDown("[8]")){
            var command = new CommandPropagate<CommandDupeAndForward>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[2]")){
            var command = new CommandPropagate<CommandDupeAndBackward>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[6]")){
            var command = new CommandPropagate<CommandDupeAndRight>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[4]")){
            var command = new CommandPropagate<CommandDupeAndLeft>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[7]")){
            var command = new CommandPropagate<CommandDupeAndForwardLeft>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[9]")){
            var command = new CommandPropagate<CommandDupeAndForwardRight>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[3]")){
            var command = new CommandPropagate<CommandDupeAndBackRight>(this);
            command.Do();
            _commandStack.Push(command);
        }

        if (Input.GetKeyDown("[1]")){
            var command = new CommandPropagate<CommandDupeAndBackLeft>(this);
            command.Do();
            _commandStack.Push(command);
        }

        //Randomize color
        if (Input.GetKeyDown(KeyCode.C)){
            var command = new CommandPropagate<ColorChangeCommand>(this);
            command.Do();
            _commandStack.Push(command);
        }

        //Create cube at the same position
        if (Input.GetKeyDown(KeyCode.D)){
            var command = new CommandPropagate<CommandDuplicateCube>(this);
            command.Do();
            _commandStack.Push(command);
        }
    }

    private void ChangeCube(Cube cube){
        if (cube == null) return;

        var command = new CommandChangeCube(this, cube);
        command.Do();
        _commandStack.Push(command);
    }

    private void KillCube(Cube cube){
        if (cube == null) return;

        var command = new KillCommand(this, cube);
        command.Do();
        _commandStack.Push(command);
    }

    private Cube PickCube(){
        if (Camera.main == null)
            throw new NullReferenceException(
                message: "Camera.main is null, can't cast a ray from non-existing camera. (Manager.PickCube())");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit, 20);
        if (hit.collider == null || hit.collider.GetComponent<Cube>() == null) return null;
        return hit.collider.GetComponent<Cube>();
    }

    private void AddCube(Cube cube){
        var command = new CommandAddCube(this, cube);
        command.Do();
        _commandStack.Push(command);
    }

    //Coroutines
    private IEnumerator ResetCoroutine(){
        _canInput = false;
        while (_commandStack.Count > 0){
            _commandStack.Pop().Undo();
            yield return new WaitForSeconds(_coroutineDelay);
        }

        _canInput = true;
    }
}