using System;

namespace PartidaLib
{
    public class Ficha
    {
        int identificacion;
        int posicion_x;
        int posicion_y;
        int color;
        int visible;
        public Ficha(int iden, int x, int y, int color, int visible)
        {
            this.identificacion = iden;
            this.posicion_x = x;
            this.posicion_y = y;
            this.color = color;
            this.visible = visible;
        }
        public int GetIdentificacion()
        {
            return this.identificacion;
        }
        public int GetPosicion_X()
        {
            return this.posicion_x;
        }
        public int GetPosicion_Y()
        {
            return this.posicion_y;
        }

        public int GetColor()
        {
            return this.color;
        }
        public int GetVisible()
        {
            return this.visible;
        }
        public void SetPosicion_X(int x)
        {
            this.posicion_x = x;
        }
        public void SetPosicion_Y(int y)
        {
            this.posicion_y = y;
        }
        public void SetVisible(int v)
        {
            this.visible = v;
        }
        public void SiguientePaso(int numero)
        {
            if (numero == 0)
            {
                this.posicion_y = this.posicion_y - 60;
            }
            if (numero == 1)
            {
                this.posicion_x = this.posicion_x + 60;
                this.posicion_y = this.posicion_y - 60;
            }
            if (numero == 2)
            {
                this.posicion_x = this.posicion_x + 60;

            }
            if (numero == 3)
            {
                this.posicion_x = this.posicion_x + 60;
                this.posicion_y = this.posicion_y + 60;
            }
            if (numero == 4)
            {
                this.posicion_x = this.posicion_x + 60;
                this.posicion_y = this.posicion_y - 60;
            }
            if (numero == 5)
            {

                this.posicion_y = this.posicion_y + 60;
            }
            if (numero == 6)
            {
                this.posicion_x = this.posicion_x - 60;
                this.posicion_y = this.posicion_y + 60;
            }
            if (numero == 7)
            {
                this.posicion_x = this.posicion_x - 60;

            }
            if (numero == 8)
            {
                this.posicion_x = this.posicion_x - 60;
                this.posicion_y = this.posicion_y - 60;
            }
        }
    }
}
