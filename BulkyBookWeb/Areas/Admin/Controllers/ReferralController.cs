using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBook.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ReferralController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReferralController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        // Get data to upsert view
        public IActionResult Upsert(int? id)
        {
            Referral referral = new();

            if (id == null || id == 0)
            {
                return View(referral);
            }
            else
            {
                referral = _unitOfWork.Referral.GetFirstOrDefault(r => r.Id == id);
                return View(referral);
            }
        }

        // Post data to db from upsert view
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(Referral obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id == 0)
                {
                    _unitOfWork.Referral.Add(obj);
                    TempData["Success"] = "New referral created successfully";
                }
                else
                {
                    _unitOfWork.Referral.Update(obj);
                    TempData["Success"] = "Referral updated successfully";
                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var referralList = _unitOfWork.Referral.GetAll();
            return Json(new { data = referralList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Referral.GetFirstOrDefault(r => r.Id == id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Referral.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });
        }
        #endregion
    }
}
