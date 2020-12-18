using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepository
{

    public enum MealDiscription
    {

        SuperSaving = 1,
        BestforTwo,
        DinnerSpecial,
        OurSignature,
        Mostpopular,

    }
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public MealDiscription Description { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }


        public Menu() { }

        public Menu(int mealNumber, string mealName, MealDiscription description , string ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;

            
        }
    }
}
