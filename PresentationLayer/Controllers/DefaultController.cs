using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Security.Cryptography.X509Certificates;

namespace PresentationLayer.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ICustomerService _customerService;

        public DefaultController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult CustomerList()
        {
            var values = _customerService.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerAdd(Customer customer)
        {
            _customerService.Insert(customer);
            return RedirectToAction("CustomerList");
        }
        [HttpGet]
        public IActionResult Transaction()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Transaction(CustomerViewModel viewModel)
        {
            var value1 = _customerService.GetByID(viewModel.SenderID);
            var value2 = _customerService.GetByID(viewModel.ReceiverID);
            value1.CustomerBalance -= viewModel.Amount;
            value2.CustomerBalance += viewModel.Amount;
            List<Customer> modifiedCustomers = new List<Customer>()
            {
                    value1, value2
            };
            _customerService.MultiUpdate(modifiedCustomers);
            return RedirectToAction("CustomerList");
        }

    }
}
