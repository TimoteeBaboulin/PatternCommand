using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour{
    private Cube _currentCube = null;
    private Stack<Command> _commandStack = new Stack<Command>();

    private void Update(){
        if (Input.GetButtonDown("Fire1"))
            PickCube();
        
        if (Input.GetButtonDown("Jump") && _commandStack.Count > 0){
            _commandStack.Pop().Undo();
        }
        
        if (_currentCube == null) return;
        
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            var newCommand = new CommandRight();
            newCommand.Do(_currentCube);
            _commandStack.Push(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            var newCommand = new CommandLeft();
            newCommand.Do(_currentCube);
            _commandStack.Push(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            var newCommand = new CommandForward();
            newCommand.Do(_currentCube);
            _commandStack.Push(newCommand);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            var newCommand = new CommandBackward();
            newCommand.Do(_currentCube);
            _commandStack.Push(newCommand);
        }

        if (Input.GetKeyDown(KeyCode.R)){
            var newCommand = new ColorChangeCommand(GetComponent<MeshRenderer>().material.color);
            newCommand.Do(_currentCube);
            _commandStack.Push(newCommand);
        }
    }

    private void PickCube(){
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, 20);
        if (hit.collider.GetComponent<Cube>() == null) return;

        if (_currentCube != null) _currentCube.GetComponent<MeshRenderer>().material.color = Color.black;
        _currentCube = hit.collider.GetComponent<Cube>();
        _currentCube.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
