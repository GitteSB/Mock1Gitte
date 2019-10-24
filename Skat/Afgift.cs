using System;

namespace Skat
{

    public class Afgift

    {
        /// <summary>
        /// Bestemmer hvilken pris en bil har med afgift alt efter hvilken pris den har
        /// </summary>
        /// <param name="pris"></param>
        /// <returns>Prisen på bilen efter afgift</returns>
       public static int bilAfgift(int pris)
        {
            // Først kaster vi en exception, i tilfælde af at der er tastet en pris ind der er under 0 kr.
            if (pris < 0)
            {
                throw new Exception("Du har indsat et tal under 0, dette kan ikke beregnes");

            }

            double BilAfgift = 0;

            if (pris <= 200000)
            {
                BilAfgift = pris * 0.85;
            }

            
            // Da vi ved der skal bruges en formel til 200000 eller under, skal der bruges en anden til hvis prisen er over 
            // 200000 kr, så bruger  jeg else da der ikke er grund til at lave en if/else.
            else
            {
                BilAfgift = (pris * 1.50) - 130000;
            }
            //Her returnere vi prisen når afgiften er indregnet
            return (int)BilAfgift;

        }   
        
        /// <summary>
        /// Beregning af prisen på en elbil
        /// </summary>
        /// <param name="pris"></param>
        /// <returns>prisen på en elbil</returns>
        public static int elBilAfgift(int pris)
            // her beregner vi prisen på en elbil udfra prisen på en almindelig bil
        {

            double elBilAfgift = bilAfgift(pris) * 0.20;
            // her returnere vil prisen på en elbil
            return (int)elBilAfgift;
        }
        
    }
}
