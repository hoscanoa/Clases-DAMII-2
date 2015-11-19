using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input.Touch;
using System.Collections.Generic;

namespace RepasoDAMII_EC3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D paleta;
        Vector2 posicionPaleta;
        Rectangle rectPaleta;

        Animacion playerAnimacion;
        //Vector2 posicionPlayer;

        Song musicaFondo;
        SoundEffect musicaExplosion;

        List<Enemigo> enemigos = new List<Enemigo>();
        int tiempoEspera = 400;
        int contadorTiempoEnemigo = 0;

        Texture2D fondo;
        Vector2 posicionFondo= Vector2.Zero;

        public void AgregarEnemigo()
        {
            Enemigo enemigo = new Enemigo();
            enemigo.Initialize(Content.Load<Texture2D>("enemigo"), new Vector2(GraphicsDevice.Viewport.Width+70, new System.Random().Next(70,GraphicsDevice.Viewport.Height-70)));

            enemigos.Add(enemigo);
        }


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            fondo = Content.Load<Texture2D>("fondo");

            playerAnimacion = new Animacion();
            playerAnimacion.Initialize(Content.Load<Texture2D>("player"), new Vector2(100, 125), 8, 115, 69, 40, 1);

            musicaFondo = Content.Load<Song>("menuMusic");
            MediaPlayer.Play(musicaFondo);
            MediaPlayer.IsRepeating = true;

            musicaExplosion = Content.Load<SoundEffect>("explosion");


            paleta = Content.Load<Texture2D>("lpaddle");
            posicionPaleta = new Vector2(100,125);
            rectPaleta = new Rectangle((int)posicionPaleta.X, (int)posicionPaleta.Y, GraphicsDevice.Viewport.Width / 20, GraphicsDevice.Viewport.Height / 5);


            TouchPanel.EnabledGestures = GestureType.FreeDrag;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            playerAnimacion.Update(gameTime);

            while(TouchPanel.IsGestureAvailable)
            {
                GestureSample gestura = TouchPanel.ReadGesture();
                if(gestura.GestureType==GestureType.FreeDrag)
                {
                    playerAnimacion.posicion += gestura.Delta;

                    //posicionPaleta += gestura.Delta;
                    rectPaleta.X = (int)posicionPaleta.X;
                    rectPaleta.Y = (int)posicionPaleta.Y;

                }
            }

            contadorTiempoEnemigo += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(contadorTiempoEnemigo>tiempoEspera)
            {
                contadorTiempoEnemigo = 0;
                AgregarEnemigo();
            }

            foreach(Enemigo e in enemigos)
            {
                e.Update(gameTime);
                if(playerAnimacion.destRect.Intersects(e.rectEnemigo))
                {
                    e.activo = false;
                    musicaExplosion.Play();
                }
                /*
                if(rectPaleta.Intersects(e.rectEnemigo))
                {
                    e.activo = false;
                }              
                 */
            }

            for (int i = enemigos.Count - 1; i>=0 ;i-- )
            {
                if(!enemigos[i].activo)
                {
                    enemigos.RemoveAt(i);
                }
            }

                base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //spriteBatch.Draw(paleta, posicionPaleta, Color.Green);
            spriteBatch.Draw(fondo, posicionFondo, Color.White);
            playerAnimacion.Draw(spriteBatch);

            //spriteBatch.Draw(paleta, rectPaleta, Color.Green);

            foreach (Enemigo e in enemigos)
            {
                e.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
