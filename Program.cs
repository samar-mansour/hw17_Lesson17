using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace hw17_1207
{
    class Program
    {
        static bool HasChildren(Citizen citizen)
        {
            if (citizen.children.Length == 0)
            {
                return false;
            }
            return true;
        }

        static bool CheckValidity(Citizen citizen)
        {
            if (HasChildren(citizen))
            {
                for (int i = 0; i < citizen.children.Length; i++)
                {
                    if (citizen.id == citizen.children[i].fatherID)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Citizen citizen1 = new Citizen("Mark", 1234);
            citizen1.children = new Citizen[2] ;

            Citizen citizen2 = new Citizen("Peter", 8596);
            citizen2.children = new Citizen[0];

            Citizen citizen3 = new Citizen("Karol", 4625);

            Citizen.idCheak = Citizen.RANDOM_NUMBER;
            Citizen[] child =
            {
                citizen1, citizen2, citizen3
            };

            citizen3.SetChildren(child);

            Console.WriteLine(citizen1);
            Console.WriteLine($"Has childrens? {HasChildren(citizen1)}");

            Console.WriteLine(citizen2);
            Console.WriteLine($"Has childrens? {HasChildren(citizen2)}");

            Console.WriteLine(citizen3);
            Console.WriteLine($"Has childrens? {HasChildren(citizen3)}");

        }
    }
}
