namespace Commands{
    public class KillCommand : CommandManager{
        private readonly Cube _cube;
        private bool _selected;
        public KillCommand(Manager context, Cube cube) : base(context){
            _cube = cube;
        }

        public override void Do(){
            _cube.gameObject.SetActive(false);
            if (_selected = _context.CurrentCube.Contains(_cube)) _context.CurrentCube.Remove(_cube);
        }

        public override void Undo(){
            _cube.gameObject.SetActive(true);
            if (_selected) _context.CurrentCube.Add(_cube);
        }
    }
}