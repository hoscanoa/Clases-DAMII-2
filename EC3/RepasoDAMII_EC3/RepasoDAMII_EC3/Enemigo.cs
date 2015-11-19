using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RepasoDAMII_EC3
{
    public class Enemigo
    {
        Texture2D imagenEnemigo;
        
        Animacion animacionEnemigo;

        Vector2 posicionEnemigo;
        public Rectangle rectEnemigo;
        Vector2 velocidadEnemigo = new Vector2(5,0);
        public bool activo;

        public void Initialize(Texture2D imagenEnemigo, Vector2 posicionEnemigo)
        {
            this.imagenEnemigo = imagenEnemigo;
            this.posicionEnemigo = posicionEnemigo;
            rectEnemigo = new Rectangle((int)posicionEnemigo.X,(int)posicionEnemigo.Y, 50, 50);
            activo = true;

            animacionEnemigo = new Animacion();
            animacionEnemigo.Initialize(this.imagenEnemigo, this.posicionEnemigo,8, 47,61,40,1);
        }

        public void Update(GameTime gameTime)
        {
            animacionEnemigo.Update(gameTime);
            animacionEnemigo.posicion -= velocidadEnemigo;
            rectEnemigo = animacionEnemigo.destRect;
            //posicionEnemigo -= velocidadEnemigo;
            //rectEnemigo.X = (int)posicionEnemigo.X;
            /*if(posicionEnemigo.X<=0)
            {
                activo = false;
            }*/
            if(animacionEnemigo.posicion.X<=0)
            {
                activo = false;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(imagenEnemigo,rectEnemigo,Color.White);
            animacionEnemigo.Draw(spriteBatch);
        }
    }
}
