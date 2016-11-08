using System;
using singleton;
using Scenes;
using Map;
using Management;

class Game : Singleton<Game>
{     
    public void Initailize()
    {
        Console.CursorVisible = false;
        //Game Start
        GameManager.GetInstance.GameStart();
        SceneManager.GetInstance.ChangeScene(new Main());
    }
    public void Update()
    {
        do
        {
            SceneManager.GetInstance.Input();
            SceneManager.GetInstance.Update();
            SceneManager.GetInstance.Draw();
            GameManager.GetInstance. Update();
        } while (GameManager.GetInstance.IsGameOn());
    }
}
