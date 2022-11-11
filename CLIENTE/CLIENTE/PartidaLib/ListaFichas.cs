using System;
using System.Collections.Generic;
using System.Text;

namespace PartidaLib
{
    class ListaFichas
    {
        const int MAX_FICHAS = 258;
        Ficha[] fichas;
        int numFichas;
        public ListaFichas()
        {
            this.fichas = new Ficha[MAX_FICHAS];
            this.numFichas = 0;
        }
        public int GetNumFichas()
        {
            return this.numFichas;
        }
        public Ficha GetFicha(int iden, int color)
        {
            if (iden < this.numFichas && fichas[iden].GetColor() == color)
            {
                return this.fichas[iden];
            }
            else
            {
                return null;

            }
        }
        public void Avanzar(int numero, int iden)
        {
            this.fichas[iden].SiguientePaso(numero);

        }
        public void CargarPartida(string datosFichas)
        {
            string[] datos = datosFichas.Split('*');
            if (Convert.ToDouble(datos[0]) == 0)
            {

                while (numFichas < MAX_FICHAS)
                {
                    if (numFichas == 0)
                    {
                        Ficha lista = new Ficha(0, 621, 261, 0, 1);
                        fichas[numFichas] = lista;
                    }
                    if (numFichas == 1)
                    {
                        Ficha lista = new Ficha(1, 561, 201, 0, 1);
                        fichas[numFichas] = lista;
                    }
                    if (numFichas > 1 && numFichas < 64)
                    {
                        Ficha lista = new Ficha(numFichas, 0, 0, 0, 0);
                        fichas[numFichas] = lista;
                    }


                    if (numFichas == 64)
                    {
                        Ficha lista = new Ficha(64, 561, 201, 1, 1);
                        fichas[numFichas] = lista;
                    }
                    if (numFichas == 65)
                    {
                        Ficha lista = new Ficha(65, 621, 201, 1, 1);
                        fichas[numFichas] = lista;
                    }
                    if (numFichas > 1 && numFichas < 64)
                    {
                        Ficha lista = new Ficha(numFichas, 0, 0, 1, 0);
                        fichas[numFichas] = lista;
                    }
                    numFichas++;
                }
            }
            if (Convert.ToDouble(datos[0]) == 1)
            {
                string[] datosFicha = datos[1].Split('/');

                while (datosFichas != null && numFichas < MAX_FICHAS)
                {

                    int iden = Convert.ToInt32(datosFicha[5 * numFichas]);
                    int p_x = Convert.ToInt32(datosFicha[1 + 5 * numFichas]);
                    int p_y = Convert.ToInt32(datosFicha[2 + +5 * numFichas]);
                    int color = Convert.ToInt32(datosFicha[3 + +5 * numFichas]);
                    int visible = Convert.ToInt32(datosFicha[4 + +5 * numFichas]);
                    Ficha lista = new Ficha(iden, p_x, p_y, color, visible);
                    fichas[numFichas] = lista;
                    numFichas++;
                }
            }

        }
    }

}
