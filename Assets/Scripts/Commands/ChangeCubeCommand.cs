using System.Collections.Generic;
using UnityEngine;

public class ChangeCubeCommand : CommandManager{
    private Cube _cube;
    private Stack<CommandCube> _subCommands = new Stack<CommandCube>();
    
    public ChangeCubeCommand(Manager context, Cube cube) : base(context){
        _cube = cube;
    }
    
    public override void Do(){
        //Change color of previously selected cube
        if (_context.CurrentCube != null){
            var command = new ColorChangeCommand(_context.CurrentCube, Color.black);
            command.Do();
            _subCommands.Push(command);
        }
        
        var oldCube = _context.CurrentCube;
        _context.CurrentCube = _cube;
        
        var colorCommand = new ColorChangeCommand(_context.CurrentCube, Color.red);
        colorCommand.Do();
        _subCommands.Push(colorCommand);
        
        _cube = oldCube;
    }

    public override void Undo(){
        foreach (var command in _subCommands){
            command.Undo();
        }
        _context.CurrentCube = _cube;
    }
}