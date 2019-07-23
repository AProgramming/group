using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using group.Models;
using Microsoft.AspNet.Identity;


namespace group.Controllers
{
    public class AdminController : Controller
    {
        groupEntities db = new groupEntities();
        ViewModel ViewModel = new ViewModel();
        // GET: Admin
        public ActionResult Index()
        {
           ViewBag.NewMessage=db.ContactUs.Where(x => x.Status == 0).Count();
            ViewBag.Product = db.Product.Count();
            ViewBag.News = db.News.Count();
            ViewBag.Member = db.Member.Count();
            return View();
        }
        #region Adding News
        [HttpGet]
        public ActionResult AddNews()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddNews(ViewModel viewModel)
        {
            try
            {
                
            Models.News news = new Models.News();
            news.Descr = viewModel.Descr;
            string fileName = Path.GetFileNameWithoutExtension(viewModel.file.FileName);
            string extension = Path.GetExtension(viewModel.file.FileName);
            fileName = fileName + " " + DateTime.Now.ToString("yymmssfff") + extension;
            viewModel.NewsImage = "~/Content/image/news/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/image/news/"), fileName);
            viewModel.file.SaveAs(fileName);
            news.Image = viewModel.NewsImage;

            db.News.Add(news);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("NewsDetail");
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                return RedirectToAction("Error");

            }
        }
        public ActionResult NewsDetail()
        {

            return View(GetNews());
        }
        IEnumerable<News> GetNews()
        {
            return db.News.ToList().OrderByDescending(x => x.Id);
        }
        [HttpGet]
        public ActionResult EditNews(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("NewsDetail");
            }
            var ev = db.News.Single(x => x.Id == id);
            ViewModel.Descr = ev.Descr;
            ViewModel.NewsImage = ev.Image;

            return View(ViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditNews(ViewModel vm)
        {
            Models.News news = new Models.News();
            news.Descr = vm.Descr;
            if (vm.file != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(vm.file.FileName);
                string extension = Path.GetExtension(vm.file.FileName);
                fileName = fileName + " " + DateTime.Now.ToString("yymmssfff") + extension;
                vm.NewsImage = "~/Content/image/news/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/image/news/"), fileName);

                vm.file.SaveAs(fileName);
                news.Image = vm.NewsImage;
            }
            else
            {

                news.Image = vm.NewsImage;
            }
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("NewsDetail");
        }
        [HttpPost]
        public ActionResult DeleteNews(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("NewsDetail");
            }
            var ev = db.News.Single(x => x.Id == id);
            db.News.Remove(ev);
            db.SaveChanges();
            return RedirectToAction("NewsDetail");
        }
        #endregion
        #region Adding Member
        [HttpGet]
        public ActionResult AddMember()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddMember(ViewModel viewModel)
        {
            try
            {
                
            Models.Member member = new Models.Member();
            member.Name = viewModel.Name;
            member.Email = viewModel.Email;
            member.Bio = viewModel.Bio;
            member.Dribble = viewModel.Dribble;
            member.Facebook = viewModel.Facebook;
            member.Instagram = viewModel.Instagram;
            member.linkedin = viewModel.linkedin;
            member.Telegram = viewModel.Telegram;
            member.Twitter = viewModel.Twitter;
            if (viewModel.file!=null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.file.FileName);
                string extension = Path.GetExtension(viewModel.file.FileName);
                fileName = fileName + " " + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.Image = "~/Content/image/member/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/image/member/"), fileName);
                viewModel.file.SaveAs(fileName);
                member.Image = viewModel.Image;

            }


            db.Member.Add(member);
            db.SaveChanges();
            ModelState.Clear();

            return RedirectToAction("MemberDetail");
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;

                return RedirectToAction("Error");

            }
        }
        public ActionResult MemberDetail()
        {

            return View(GetMember());
        }
        IEnumerable<Member> GetMember()
        {
            return db.Member.ToList().OrderByDescending(x => x.Id);
        }
        [HttpGet]
        public ActionResult EditMember(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("MemberDetail");
            }
            var viewModel = db.Member.Single(x => x.Id == id);
            ViewModel.Name = viewModel.Name;
            ViewModel.Email = viewModel.Email;
            ViewModel.Bio = viewModel.Bio;
            ViewModel.Dribble = viewModel.Dribble;
            ViewModel.Facebook = viewModel.Facebook;
            ViewModel.Instagram = viewModel.Instagram;
            ViewModel.linkedin = viewModel.linkedin;
            ViewModel.Telegram = viewModel.Telegram;
            ViewModel.Twitter = viewModel.Twitter;
            ViewModel.Image = viewModel.Image;


            return View(ViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMember(ViewModel viewModel)
        {
            Models.Member member = new Models.Member();
            member.Name = viewModel.Name;
            member.Email = viewModel.Email;
            member.Bio = viewModel.Bio;
            member.Dribble = viewModel.Dribble;
            member.Facebook = viewModel.Facebook;
            member.Instagram = viewModel.Instagram;
            member.linkedin = viewModel.linkedin;
            member.Telegram = viewModel.Telegram;
            member.Twitter = viewModel.Twitter;

            if (viewModel.file != null)
            {

                string fileName = Path.GetFileNameWithoutExtension(viewModel.file.FileName);
                string extension = Path.GetExtension(viewModel.file.FileName);
                fileName = fileName + " " + DateTime.Now.ToString("yymmssfff") + extension;
                viewModel.Image = "~/Content/image/member/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/image/member/"), fileName);

                viewModel.file.SaveAs(fileName);
                member.Image = viewModel.Image;
            }
            else
            {

                member.Image = viewModel.Image;
            }
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("MemberDetail");
        }
        [HttpPost]
        public ActionResult DeleteMember(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("MemberDetail");
            }
            var ev = db.Member.Single(x => x.Id == id);
            db.Member.Remove(ev);
            db.SaveChanges();
            return RedirectToAction("MemberDetail");
        }

        #endregion
        #region Adding Product
        [HttpGet]
        public ActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ViewModel viewModel)
        {
            try
            {

          
            Models.Product product = new Models.Product();
            product.Comment = viewModel.Comment;
            product.Customer = viewModel.Customer;
            product.Number = viewModel.Number;
            product.ProductDesc = viewModel.ProductDesc;
            product.ProductName = viewModel.ProductName;

            string fileName = Path.GetFileNameWithoutExtension(viewModel.file.FileName);
            string extension = Path.GetExtension(viewModel.file.FileName);
            fileName = fileName + " " + DateTime.Now.ToString("yymmssfff") + extension;
            viewModel.CustomerImage = "~/Content/image/product/customer/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Content/image/product/customer/"), fileName);
            viewModel.file.SaveAs(fileName);
            product.Image = viewModel.CustomerImage;

            string fileName2 = Path.GetFileNameWithoutExtension(viewModel.file2.FileName);
            string extension2 = Path.GetExtension(viewModel.file2.FileName);
            fileName2 = fileName2 + " " + DateTime.Now.ToString("yymmssfff") + extension2;
            viewModel.ProductImage = "~/Content/image/product/product/" + fileName2;
            fileName2 = Path.Combine(Server.MapPath("~/Content/image/product/product/"), fileName2);
            viewModel.file.SaveAs(fileName2);
            product.ProductImage = viewModel.ProductImage;

            db.Product.Add(product);
            db.SaveChanges();
            ModelState.Clear();
            ViewData["ID"] = product.Id;

            return RedirectToAction("ProductMember");
            }
            catch (Exception ex)
            {
                ViewData["message"] = ex.Message;
                return RedirectToAction("Error");

            }
        }
        public ActionResult ProductDetail()
        {

            return View(GetProduct());
        }
        IEnumerable<Product> GetProduct()
        {
            return db.Product.ToList().OrderByDescending(x => x.Id);
        }

        [HttpGet]
        public ActionResult EditProduct(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("ProductDetail");
            }
            var ev = db.Product.Single(x => x.Id == id);
            ViewModel.Comment = ev.Comment;
            ViewModel.Customer = ev.Customer;
            ViewModel.Number = ev.Number;
            ViewModel.ProductDesc = ev.ProductDesc;
            ViewModel.ProductName = ev.ProductName;
            ViewModel.CustomerImage = ev.Image;
            ViewModel.ProductImage = ev.ProductImage;

            return View(ViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProduct(ViewModel vm)
        {
            Models.Product product = new Models.Product();
            product.Comment = vm.Comment;
            product.Customer = vm.Customer;
            product.Number = vm.Number;
            product.ProductDesc = vm.ProductDesc;
            product.ProductName = vm.ProductName;
            if (vm.file != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(vm.file.FileName);
                string extension = Path.GetExtension(vm.file.FileName);
                fileName = fileName + " " + DateTime.Now.ToString("yymmssfff") + extension;
                vm.CustomerImage = "~/Content/image/product/customer/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/image/product/customer/"), fileName);
                vm.file.SaveAs(fileName);
                product.Image = vm.CustomerImage;
            }
            else
            {
                product.Image = vm.CustomerImage;
            }
            if (vm.file2 != null)
            {
                string fileName2 = Path.GetFileNameWithoutExtension(vm.file2.FileName);
                string extension2 = Path.GetExtension(vm.file2.FileName);
                fileName2 = fileName2 + " " + DateTime.Now.ToString("yymmssfff") + extension2;
                vm.ProductImage = "~/Content/image/product/product/" + fileName2;
                fileName2 = Path.Combine(Server.MapPath("~/Content/image/product/product/"), fileName2);
                vm.file.SaveAs(fileName2);
                product.ProductImage = vm.ProductImage;
            }
            else
            {
                product.Image = vm.ProductImage;
            }


            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("ProductDetail");
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("ProductDetail");
            }
            var ev = db.Product.Single(x => x.Id == id);
            db.Product.Remove(ev);
            db.SaveChanges();
            return RedirectToAction("ProductDetail");
        }
        #endregion
        #region ContactPm
        public ActionResult ContactPM()
        {

            return View(GetContactPM());
        }
        IEnumerable<ContactUs> GetContactPM()
        {
            return db.ContactUs.ToList().OrderByDescending(x => x.Id);
        }
        [HttpGet]
        public ActionResult show(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("ContactPM");
            }
            var cu = db.ContactUs.Single(x => x.Id == id);
            ViewModel contactUs = new ViewModel();
            contactUs.UserName = cu.UserName;

            contactUs.Email = cu.Email;
            contactUs.Subject = cu.Subject;
            contactUs.PM = cu.PM;
            contactUs.Status = 1;
            cu.Status = contactUs.Status;
            db.SaveChanges();

            return View(contactUs);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult show(ViewModel cu)
        {
            int id = cu.Id;
            Models.ContactUs contactUs = db.ContactUs.Find(id);
            contactUs.UserName = cu.UserName;
            contactUs.Email = cu.Email;
            contactUs.Subject = cu.Subject;
            contactUs.PM = cu.PM;
            contactUs.Status = 1;
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("ContactPM");
        }
        [HttpPost]
        public ActionResult DeleteContactPM(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("ContactPM");
            }
            var ev = db.ContactUs.Single(x => x.Id == id);
            db.ContactUs.Remove(ev);
            db.SaveChanges();
            return RedirectToAction("ContactPM");
        }
        #endregion

        public ActionResult Error()
        {
            ViewBag.ms =ViewData["message"];
                return View();
        }
    }
}