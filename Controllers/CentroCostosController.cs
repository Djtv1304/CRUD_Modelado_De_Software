using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ejemplo1.Models;
using Ejemplo1.API;

namespace Ejemplo1.Controllers
{
    public class CentroCostosController : Controller
    {

        private readonly IAPIService _apiService;

        public CentroCostosController( IAPIService IAPIService)
        {
            // Inyecto la dependencia de mi interfaz para poder hacer uso de mis métodos GET, POST, PUT, DELETE
            _apiService = IAPIService;

        }
        

        // GET: ProductoController
        public async Task<IActionResult> Index()
        {

            try 
            {

                List<CentroCostos> ListCentroCostos = await _apiService.GetCentroCostos();

                

                return View(ListCentroCostos);
            }
            catch (Exception error)
            {

                return View();

            }
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // Etiqueta propia de ASP .NET
        public async Task<IActionResult> Create(CentroCostos CentroCostosNew) //Aquí recibo el objeto de tipo producto
        {
            //if (producto != null)
            //{
            //    int i = Utils.Utils.ListaProductos.Count() + 1;
            //    producto.IdProducto = i;
            //    Utils.Utils.ListaProductos.Add(producto); // Agrego el producto a la lista

            //}

            try
            {
                if (CentroCostosNew != null)
                {

                    // Invoco a la API y le envío el nuevo producto
                    await _apiService.InsertCentroCostos(CentroCostosNew); 
                    // Redirijo a la vista principal
                    return RedirectToAction("Index"); 

                }

            } catch (Exception error)
            {

                return View();

            }

            return View();
        }


        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int CodigoCentroCostos)
        {

            try
            {

                // Busco el producto mediante una función anónima
                //Producto producto = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == IdProducto);

                // Invoco a la API y traigo mi producto en base al ID
                List<CentroCostos> ListCentroCostos = await _apiService.GetCentroCostos();

                CentroCostos CentroCostosFounded = ListCentroCostos.FirstOrDefault(data => data.Codigo == CodigoCentroCostos);

                if (CentroCostosFounded != null)
                {

                    // Retorno el producto a la vista
                    return View(CentroCostosFounded);

                }
            }

            catch (Exception error)
            {

                return View();

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CentroCostos newCentroCostos)
        {

            try
            {

                if (newCentroCostos != null)
                {

                    // Envío a la API el nuevo centro costos
                    await _apiService.UpdateCentroCostos(newCentroCostos);

                    return RedirectToAction("Index");

                }
                // Retorno el producto a la vista
                return View();

            }

            catch (Exception error) 
            {
                
                return RedirectToAction("Home");

            }
        }


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int CodigoCentroCostos)
        {
            // Busco el producto mediante una función anónima
            //Producto producto2 = Utils.Utils.ListaProductos.Find(ObjetoActual => ObjetoActual.IdProducto == IdProducto);
            try
            {

                if (CodigoCentroCostos >= 0)
                {

                    List<CentroCostos> ListCentroCostos = await _apiService.GetCentroCostos();

                    CentroCostos CentroCostosToDelete = ListCentroCostos.FirstOrDefault(data => data.Codigo == CodigoCentroCostos);

                    await _apiService.DeleteCentroCostos(CentroCostosToDelete);
                    return RedirectToAction("Index");

                }

            }
            catch (Exception error)
            {

                return View();

            }

            return RedirectToAction("Index");

        }
    }
}
