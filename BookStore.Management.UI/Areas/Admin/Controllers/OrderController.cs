using BookStore.Management.Application.Abstracts;
using BookStore.Management.Application.DTOs;
using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Management.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BreadScrum("Order List", "Application")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetByPagination(RequestDatatable requestDatatable)
        {
            var data = await _orderService.GetByPaginationAsync(requestDatatable);

            return Json(data);
        }
    }
}
