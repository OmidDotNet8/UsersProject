using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UExample.Core;
using UExample.DataLayer;

namespace UExample.web.Controllers
{
    public class HomeController : Controller
    {
        #region My Repository

        private IUser _user;

        public HomeController(IUser user)
        {
            _user = user;
        }

        #endregion

        #region User Views
        //Methods
        public IActionResult Index1()
        {
            var UPList = _user.GetAllUsers();
            return View(UPList);
        }

        public IActionResult Details1(Guid id)
        {
            var userD1 = _user.GetUserPassByID(id);
            return View(userD1);
        }

        public IActionResult Delete(Guid id)
        {
            User user = _user.GetUserPassByID(id);
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteIsDone(Guid id, UserDetail detail)
        {
            if (detail.Bio != null)
            {
                return BadRequest();
            }
            _user.DeleteUser(id);
            return RedirectToAction("Index1");
        }

        #endregion

        #region User Details Views

        public async Task<IActionResult> Index()
        {
            var UList = await _user.GetAllUsersDetails();
            return View(UList);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var userD = await _user.GetUserByID(id);
            return View(userD);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserViewModel viewModel)
        {
            _user.AddToUser(viewModel);
            return RedirectToAction("Index1");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            UserDetail detail = await _user.GetUserByID(id);

            if (detail == null)
            {
                return NotFound();
            }

            return View(detail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserDetail detail)
        {
            _user.UpdateUser(detail);
            return RedirectToAction("Index");          
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _user.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}

