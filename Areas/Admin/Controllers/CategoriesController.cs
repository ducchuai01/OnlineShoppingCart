using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EProjects_III.Models;
using X.PagedList;
using System.IO;

namespace EProjects_III.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly OnlineShoppingCartContext _context;

        public CategoriesController(OnlineShoppingCartContext context)
        {
            _context = context;
        }

        // GET: Admin/Categories
        public IActionResult Index(string Search, int page = 1)
        {
            int limit = 5;
            var list = _context.Category.OrderBy(c => c.CategoryId).ToPagedList(page, limit);
            if (!string.IsNullOrEmpty(Search))
            {
                list = _context.Category.Where(c => c.CategoryName.Contains(Search)).OrderBy(c => c.CategoryId).ToPagedList(page, limit);
            }
            return View(list);
        }

        // GET: Admin/Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Categories/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ImgCategory", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    category.Image = FileName; // gán tên ảnh cho thuộc tinh Image
                }
                category.CreatedAt = DateTime.Now;
                category.DeleteAt = DateTime.Now;
                category.ModifiedAt = DateTime.Now;
            }
            _context.Category.Add(category);
            _context.SaveChangesAsync();
            TempData["success"] = "Thêm mới thành công";
            return RedirectToAction("Index");
        }

        // GET: Admin/Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category,int id , string oldImg)
        {
            var files = HttpContext.Request.Form.Files;
            if (files.Count() > 0 && files[0].Length > 0)
            {
                var file = files[0];
                var FileName = file.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ImgCategory", FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                    category.Image = FileName; // gán tên ảnh cho thuộc tinh Image
                }
                category.CreatedAt = DateTime.Now;
                category.DeleteAt = DateTime.Now;
                category.ModifiedAt = DateTime.Now;
            }
            else
            {
                category.Image = oldImg;
            }
            _context.Category.Update(category);
            _context.SaveChangesAsync();
            TempData["success"] = "Sửa thành công";
            return RedirectToAction("Index");

        }

        // GET: Admin/Categories/Delete/5
        public IActionResult Delete(int id)
        {
            var checkProduct = _context.Products.FirstOrDefault(p => p.CategoryId == id);
            if (checkProduct != null)
            {
                TempData["eror"] = "Categories exist products that cannot be deleted!";
                return RedirectToAction("Index");
            }
            else
            {
                var category = _context.Category.FirstOrDefault(b => b.CategoryId == id);
                if (category != null)
                {
                    _context.Category.Remove(category);
                    _context.SaveChanges();
                    TempData["success"] = "Xóa thành công";
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }
        //// POST: Admin/Categories/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int? id)
        //{
        //    var category = await _context.Category.FindAsync(id);
        //    _context.Category.Remove(category);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //    //var checkCate = _context.Category.FirstOrDefault(c => c.CategoryId == id && c.ParentId.Equals("0"));
        //    //var checkPro = _context.Products.FirstOrDefault(p => p.CategoryId == id);
        //    //if (checkCate != null || checkPro != null)
        //    //{
        //    //    TempData["eror"] = "Danh mục tồn tại sản phẩm hoặc là danh mục cha không thể xóa!";
        //    //    return RedirectToAction("Index");
        //    //}
        //    //var cate = _context.Category.FirstOrDefault(c => c.CategoryId == id);
        //    //if (cate != null)
        //    //{
        //    //    _context.Category.Remove(cate);
        //    //    _context.SaveChanges();
        //    //    TempData["success"] = "Xóa thành công";
        //    //    return RedirectToAction("Index");
        //    //}

        //    //return RedirectToAction("Index");
        //}

        private bool CategoryExists(int? id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
