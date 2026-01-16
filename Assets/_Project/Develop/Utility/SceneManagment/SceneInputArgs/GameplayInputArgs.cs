namespace Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(Behaviors behavior, Difficulties difficulty)
        {
            Behavior = behavior;
            Difficulty = difficulty;
        }

        public Behaviors Behavior { get; }
        public Difficulties Difficulty { get; }
    }
}
