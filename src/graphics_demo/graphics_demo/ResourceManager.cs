using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;

namespace graphics_demo
{
    public class ResourceManager
    {
        private static ResourceManager instance = null;

        Dictionary<string, Texture> _textures = new Dictionary<string, Texture>();
        Dictionary<string, Image> _images = new Dictionary<string, Image>(); 

        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResourceManager();
                }
                return instance;
            }
        }

        public void LoadImageFromFile(string name, string path)
        {
            Image image = new Image(path);
            _images.Add(name, image);
        }

        public Image GetImage(string name)
        {
            return _images[name];
        }

        public void LoadTextureFromFile(string name, string path)
        {
            Texture texture = new Texture(path);
            _textures.Add(name, texture);
        }

        public Texture GetTexture(string name)
        {
            return _textures[name];
        }
    }
}
