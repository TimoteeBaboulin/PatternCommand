using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour{
    public Cube CurrentCube;
    
    public Context Context{
        get => new Context(CurrentCube, this);
    }
    
    private Stack<Command> _commandStack = new Stack<Command>();

    public void ChangeCube(Cube cube){
        if (cube == null || cube == CurrentCube) return;

        var command = new ChangeCubeCommand(this, cube);
        command.Do();
        _commandStack.Push(command);
    }

    public void KillCube(Cube cube){
        if (cube == null) return;

        var command = new KillCommand(cube);
        command.Do();
        _commandStack.Push(command);
    }
    
    private void Update(){
        if (Input.GetButtonDown("Fire1"))
            ChangeCube(PickCube());

        if (Input.GetButtonDown("Fire2")){
            KillCube(PickCube());
        }
            
        
        if (Input.GetButtonDown("Jump") && _commandStack.Count > 0){
            _commandStack.Pop().Undo();
        }
        
        if (CurrentCube == null) return;
        
        //Movement
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            var command = new CommandRight(CurrentCube);
            command.Do();
            _commandStack.Push(command);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            var command = new CommandLeft(CurrentCube);
            command.Do();
            _commandStack.Push(command);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            var command = new CommandForward(CurrentCube);
            command.Do();
            _commandStack.Push(command);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            var command = new CommandBackward(CurrentCube);
            command.Do();
            _commandStack.Push(command);
        }

        //Randomize color
        if (Input.GetKeyDown(KeyCode.R)){
            var command = new ColorChangeCommand(CurrentCube, Random.ColorHSV());
            command.Do();
            _commandStack.Push(command);
        }
    }

    private Cube PickCube(){
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hit, 20);
        if (hit.collider.GetComponent<Cube>() == null) return null;
        return hit.collider.GetComponent<Cube>();
    }
}

public readonly struct Context{
    public readonly Cube Cube;
    public readonly Manager Manager;

    public Context(Cube cube, Manager manager){
        Cube = cube;
        Manager = manager;
    }
}
