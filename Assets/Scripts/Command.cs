public abstract class Command{
    protected Cube _cube;
    
    public abstract void Do(Cube cube);
    public abstract void Undo();
}