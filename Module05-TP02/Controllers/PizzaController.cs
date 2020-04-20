using Module05_TP02.Models;
using Module05_TP02.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Module05_TP02.Controllers
{
    public class PizzaController : Controller
    {

        public List<Pizza> Pizzas = DataDb.Instance.pizzas;
        public List<Pate> Pates = DataDb.Instance.pates;
        public List<Ingredient> Ingredients = DataDb.Instance.ingredients;


        // GET: Pizza
        public ActionResult Index()
        {
            return View(Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            Pizza pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Ingredients = Ingredients;
            vm.Pates = Pates;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                // Sélection de la pate choisie par l'user dans la liste des pates Pates
                vm.Pizza.Pate = Pates.FirstOrDefault(x => x.Id == vm.IdPate);

                //Sélection du ou des ingrédient()s choisi(s) par l'user dans la liste des ingrédients Ingredients
                foreach (var ingredient in Ingredients)
                {
                    foreach (var idIngredient in vm.IdsIngredient)
                    {
                        if (ingredient.Id == idIngredient)
                        {
                            vm.Pizza.Ingredients.Add(ingredient);
                        }
                    }
                }

                DataDb.Instance.Pizzas.Add(vm.Pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {

            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = DataDb.Instance.pizzas.FirstOrDefault(p => p.Id == id);
            vm.Ingredients = Ingredients;
            vm.Pates = Pates;

            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateViewModel vm)
        {
            try
            {
                //La liste des différentes pates
                var Pates = DataDb.Instance.pates;
                //la liste des différents ingrédients
                var Ingredients = DataDb.Instance.ingredients;
                //On récupère la Pizza présente dans DataDb
                Pizza pizza = DataDb.Instance.pizzas.FirstOrDefault(p => p.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = Pates.FirstOrDefault(x => x.Id == vm.IdPate);


                //Sélection du ou des ingrédient()s choisi(s) par l'user dans la liste des ingrédients Ingredients
                foreach (var ingredient in Ingredients)
                {
                    foreach (var idIngredient in vm.IdsIngredient)
                    {
                        if (ingredient.Id == idIngredient)
                        {
                            pizza.Ingredients.Add(ingredient);
                        }
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }


        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            Pizza pizza = Pizzas.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = DataDb.Instance.Pizzas.FirstOrDefault(p => p.Id == id);
                DataDb.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
