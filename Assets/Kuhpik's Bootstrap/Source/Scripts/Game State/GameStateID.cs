namespace Kuhpik
{
    public enum GameStateID
    {
        // Don't change int values in the middle of development.
        // Otherwise all of your settings in inspector can be messed up.

        Menu = 0,
        Game = 1,
        Win = 2,
        Lose = 3,

        // Extend just like that
        //
        // Revive = 100,
        // QTE = 200
    }
}