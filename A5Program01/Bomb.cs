using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5Program01
{
    internal class Bomb
    {

        private float _speedX;
        private float _speedY;
        private Texture2D _bombSprite;
        private float _bombX;
        private float _bombY;

        Random _rng = new Random();


        public Bomb(Texture2D bombSprite)
        {
            _bombSprite = bombSprite;

            _bombX = 100;
            _bombY = 100;

            _speedX = 4;
            _speedY = 5;

        }


        public float GetX()
        {
            return _bombX;
        }

        public float GetY()
        {
            return _bombY;
        }


        public bool CollideWithWall(Wall wall)
        {
            Rectangle wallBounds = wall.GetBounds();
            Rectangle bombBounds = GetBounds();

            if (bombBounds.Intersects(wallBounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }





            }
        public Rectangle GetBounds()
        {
            return new Rectangle((int)_bombX, (int)_bombY, _bombSprite.Width / 4, _bombSprite.Height / 4);
        }

        public void ChangeDirection(int speed)
        {
            _speedY = _speedY * speed;

            if (_rng.Next(0, 2) == 1)
            {
                _speedX = _rng.Next(1, 3);
            }
            else
            {
                _speedX = _rng.Next(1, 3) * -1;
            }
        }

        public void ChangeDirectionWall()
        {


            if (_speedY == -5)
            {
                _speedX = _rng.Next(1, 3);
            }
            else if (_speedY == 5)
            {
                _speedX = _rng.Next(1, 3) * -1;
            }
        }

        public void Update()
        {
            _bombX -= _speedX;
            _bombY -= _speedY;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            //public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)

            spriteBatch.Draw(_bombSprite,   //sprite
            new Vector2(_bombX, _bombY),  //location
            null, //rectangle
            Color.White, //color
            0f, //rotation
            new Vector2(0, 0),  //origin
            0.25f,   //scale
            SpriteEffects.None,  //effects
            0   //layer
            );


            spriteBatch.End();
        }
    }
}
