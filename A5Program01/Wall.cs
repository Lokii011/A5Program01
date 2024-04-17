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
    internal class Wall
    {

        private Texture2D _wallSprite;
        private float _wallX;
        private float _wallY;

        Random _rng;

        public Wall(Texture2D wallSprite)
        {
            _rng = new Random();
            _wallSprite = wallSprite;
            _wallX = _rng.Next(0, 740);
            _wallY = _rng.Next(0, 420);
        }


        public bool CollideWithPlayer(Player player)
        {
            Rectangle playerBounds = player.GetBounds();
            Rectangle wallBounds = GetBounds();


            if (wallBounds.Intersects(playerBounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        public Rectangle GetBounds()
        {
            return new Rectangle((int)_wallX, (int)_wallY, _wallSprite.Width, _wallSprite.Height);
        }









        public void Draw(SpriteBatch spriteBatch) 
        {
            spriteBatch.Begin();
            spriteBatch.Draw(_wallSprite, //sprite
            new Vector2(_wallX, _wallY), //location
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
