using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace graphics_demo
{
    public class SceneManager
    {
        private static SceneManager instance = null;
        Dictionary<string,Scene> _scenes = new Dictionary<string, Scene>();

        public Scene CurrentScene = null;

        public static SceneManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SceneManager();
                }
                return instance;
            }
        }

        public void AddScene(Scene s)
        {
            _scenes.Add(s.Name, s);
            s.Initialize();
        }

        public void StartScene(string name)
        {
            CurrentScene = _scenes[name];
            CurrentScene.Reset();
            CurrentScene.Run();
        }

        public void GotoScene(string name)
        {
            CurrentScene = _scenes[name];
            CurrentScene.Run();
        }
    }
}
