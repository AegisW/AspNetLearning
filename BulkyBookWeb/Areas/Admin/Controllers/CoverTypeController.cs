using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> objCoverTypeList = _unitOfWork.CoverType.GetAll();
            return View(objCoverTypeList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Cover type created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        //Get
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverType.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Cover type udpated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var coverTypeFromDb = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);

            if (coverTypeFromDb == null)
            {
                return NotFound();
            }

            return View(coverTypeFromDb);
        }

        //Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _unitOfWork.CoverType.GetFirstOrDefault(c => c.Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.CoverType.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Cover type deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
