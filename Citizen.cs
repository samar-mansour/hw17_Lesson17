using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw17_1207
{
    class Citizen
    {
        public string name;
        public Citizen[] children = new Citizen[0];
        public readonly int fatherID;
        public readonly int id;
        public static int numberOfCurrentCitizens = 0;
        public const int MAXIMUM_NUMBER_OF_CITIZENS = 10000;

        public static Random rnd = new Random();

        public static int idCheak = RANDOM_NUMBER; // 1.auto-increment 2.Random
        public const int AUTO_INCREMENT = 1; 
        public const int RANDOM_NUMBER = 2;

        public static bool[] idArray = new bool[MAXIMUM_NUMBER_OF_CITIZENS];

        public Citizen(string name, int fatherID)
        {
            this.name = name;
            this.fatherID = fatherID;

            //everytime we create instanse we'll increasing citizin number
            numberOfCurrentCitizens++;

            switch (idCheak)
            {
                case AUTO_INCREMENT:
                    this.id = numberOfCurrentCitizens;
                    break;
                case RANDOM_NUMBER:
                    int newId = 0;
                    do
                    {
                        newId = rnd.Next(MAXIMUM_NUMBER_OF_CITIZENS + 1);
                    } while (idArray[newId] == true);
                    idArray[newId] = true;
                    this.id = newId;
                    break;
            }
        }

        public static void PrintNumberOfCitizens()
        {
            Console.WriteLine(Citizen.numberOfCurrentCitizens);
        }

        public static bool ReachedHalfOfMaximumSize()
        {
            if (Citizen.numberOfCurrentCitizens >= Citizen.MAXIMUM_NUMBER_OF_CITIZENS)
            {
                return true;
            }
            return false;
        }

        public void PrintID()
        {
            Console.WriteLine(this.id);
        }

        public void PrintGapBetweenMyIDAndFather()
        {
            Console.WriteLine(Math.Abs(this.fatherID - this.id));
        }

        public void SetChildren(Citizen[] children)
        {
            this.children = children;
        }

        public override string ToString()
        {
            return $"[{base.ToString()}]: name: {this.name} Father ID: {this.fatherID} ID: {this.id}";
        }
    }
}
