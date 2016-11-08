using singleton;
using Scenes.Standard;

namespace Management
{
    class SceneManager : Singleton<SceneManager>
    {
        private Scene CurrentScene;
        public void Input()
        {
            CurrentScene.Input();
        }
        public void Dispose()
        {
            CurrentScene.Dispose();
        }
        public void Update()
        {
            CurrentScene.Update();
        }
        public void Draw()
        {
            CurrentScene.Draw();
        }
        public bool ChangeScene(Scene NewScene)
        {
            if(NewScene.Initialize() == false)
            {
                return false;
            }
            CurrentScene = NewScene;
            return true;
        }
    }
}
