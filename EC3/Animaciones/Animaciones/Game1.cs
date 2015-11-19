using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Animaciones
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //variables para el fondo
        Texture2D fondo;
        Vector2 posicionFondo = Vector2.Zero;
        Rectangle rectFondo;
        
        //variables para la animacion
        Animacion animacion;
        Vector2 velocidadAnimacion = new Vector2(10, 0);

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

            fondo = Content.Load<Texture2D>("Fondo");
            rectFondo = new Rectangle((int)posicionFondo.X,
                (int)posicionFondo.Y, GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height);

            animacion = new Animacion();
            animacion.Initialize(Content.Load<Texture2D>("spriteanimation"),
                new Vector2(GraphicsDevice.Viewport.Width - 96, 265), 10, 96, 96, 15, 1);



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

            animacion.Update(gameTime);
            animacion.posicion -= velocidadAnimacion;
            if (animacion.posicion.X <= 0 || animacion.posicion.X >
                GraphicsDevice.Viewport.Width - 96)
            {
                velocidadAnimacion *= -1;
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

            spriteBatch.Draw(fondo, rectFondo, Color.White);
            animacion.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
