namespace Commands{
    public class KillCommand : CommandCube{
        public KillCommand(Cube context) : base(context){
        }

        public override void Do(){
            _context.gameObject.SetActive(false);
        }

        public override void Undo(){
            _context.gameObject.SetActive(true);
        }
    }
}