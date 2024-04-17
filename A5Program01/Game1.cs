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
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Attributes
        private Bomb _bomb;
        private Player _player;
        private Wall _wall;
        private Superbomb _superBomb;
        private Fire _fire;
        private Texture2D _playerSprite;
        private List<Bomb> _bombList;
        private List<Superbomb> _superBombList;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _bombList = new List<Bomb>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerSprite = Content.Load<Texture2D>("Player");
            _player = new Player(10, _playerSprite);

            _bombList.Add(new Bomb(Content.Load<Texture2D>("Bomb")));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            _player.Update(gameTime);

            /*
                        //Wall collision didn't work properly, wither phases through or stops inside and stops movement completely
                        if (_wall.CollideWithPlayer(_player))
                        {

                        }
                        else 
                        {
                             _player.Update(gameTime);
                        }
            

            if (_bombList.Count > 0) 
            { 
                if (_player.CollideWithBomb(_ballList[0]))
                {

                    _bombList.Remove(_bombList[0]);
                }
            }
            */
            //Keep the player on screen
            if (_player.GetX() < 0)
            {
                _player.ResetLeft();
            }
            if (_player.GetX() > 740)
            {
                _player.ResetRight();
            }
            if (_player.GetY() < 0)
            {
                _player.ResetUp();
            }
            if (_player.GetY() > 420)
            {
                _player.ResetDown();
            }


            //Keep bomb on screen
            if (_bombList[0].GetY() < 0)
            {
                _bombList[0].ChangeDirection(-1);
            }
            else if (_bombList[0].GetX() <= 0)
            {
                _bombList[0].ChangeDirectionWall();
            }
            else if (_bombList[0].GetX() >= 680)
            {
                _bombList[0].ChangeDirectionWall();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);

        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _player.Draw(_spriteBatch);

            _bombList[0].Draw(_spriteBatch);

            //wall crashes the program
            //_wall.Draw(_spriteBatch);
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
