namespace Commands{
    public abstract class Command{
        public abstract void Do();
        public abstract void Undo();
    }

    public abstract class Command<T> : Command{
        protected T _context;

        protected Command(T context){
            _context = context;
        }
    }

    public abstract class CommandManager : Command<Manager>{
        protected CommandManager(Manager context) : base(context){
        }
    }

    public abstract class CommandCube : Command<Cube>{
        protected CommandCube(Cube context) : base(context){
        }
    }
}