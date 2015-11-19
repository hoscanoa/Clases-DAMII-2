using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Animaciones
{
    public class Animacion
    {
        Texture2D imagenAnimar;
        public Vector2 posicion;
        int frameCount;
        int frameWidth;
        int frameHeight;
        int tiempoEspera;
        int escala;
        int currentFrame;
        int contadorTiempo;
        Rectangle sourceRect, destRect;

        public void Initialize(Texture2D imagenAnimar,
            Vector2 posicion,int frameCount,int frameWidth,
            int frameHeight,int tiempoEspera,int escala)
        {
            this.imagenAnimar = imagenAnimar;
            this.posicion = posicion;
            this.frameCount = frameCount;
            this.frameWidth = frameWidth;
            this.frameHeight = frameHeight;
            this.tiempoEspera = tiempoEspera;
            this.escala = escala;
            contadorTiempo = 0;
            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {
            contadorTiempo +=
                (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (contadorTiempo > tiempoEspera)
            {
                contadorTiempo = 0;
                currentFrame += 1;
                if (currentFrame >= frameCount)
                {
                    currentFrame = 0;
                }
            }
            
            sourceRect = new Rectangle(frameWidth*currentFrame, 
                0,
                frameWidth, frameHeight);

            destRect = new Rectangle((int)posicion.X, (int)posicion.Y,
                escala * frameWidth, escala * frameHeight);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(imagenAnimar, destRect, sourceRect, Color.White);
        }
    }
}
