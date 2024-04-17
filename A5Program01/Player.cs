using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace A5Program01
{
    internal class Player
    {
        
        private int _speed;
        private Texture2D _playerSprite;
        private float _playerX, _playerY;
        private int _direction;

        public Player(int speed, Texture2D playerSprite)
        {
            _speed = speed;
            _playerSprite = playerSprite;
            _playerX = 200;
            _playerY = 400;

        }



        public float GetX()
        {
            return _playerX;
        }

        public float GetY() 
        {
            return _playerY;
        }

        //Keep the player on screen

        public void ResetLeft()
        {
            _playerX += _speed;
        }

        public void ResetRight()
        {
            _playerX -= _speed;
        }

        public void ResetUp()
        {
            _playerY += _speed;
        }

        public void ResetDown()
        {
            _playerY -= _speed;
        }




        public Rectangle GetBounds()
        {
            return new Rectangle((int)_playerX, (int)_playerY, _playerSprite.Width, _playerSprite.Height);
        }


        public bool CollideWithBomb(Player player)
        {
            Rectangle playerBounds = GetBounds();
            Rectangle bombBounds = player.GetBounds();

            if (bombBounds.Intersects(playerBounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
            public void Update(GameTime gameTime)
        {




            //Movement


            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _playerX += _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _playerX -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _playerY -= _speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _playerY += _speed;
            }
            



        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();


            spriteBatch.Draw(_playerSprite,   //sprite
            new Vector2(_playerX, _playerY),  //location
            null, //rectangle
            Color.White, //color
            0f, //rotation
            new Vector2(0, 0),  //origin
            1f,   //scale
            SpriteEffects.None,  //effects
            0   //layer
            );


            spriteBatch.End();
        }
    }
}
