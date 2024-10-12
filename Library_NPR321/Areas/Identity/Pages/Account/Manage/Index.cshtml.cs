// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Library_NPR321.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Library_NPR321.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        private const string DefaultAvatarPath = "~/uploads/default-avatar.png";

        public string Username { get; set; }

        public string AvatarPath { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };

            AvatarPath = user.Image;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostRemoveAvatarAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Не вдалося знайти користувача з ID {user.Id}.");
            }

            if (!string.IsNullOrEmpty(user.Image) && user.Image != "~/uploads/default-avatar.png")
            {
                var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", user.Image);

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                user.Image = "~/uploads/default-avatar.png";
                var result = await _userManager.UpdateAsync(user);

                if (!result.Succeeded)
                {
                    StatusMessage = "Не вдалося оновити користувача. Спробуйте ще раз.";
                    return RedirectToPage();
                }

                StatusMessage = "Аватар успішно видалено.";
            }
            else
            {
                StatusMessage = "Аватар не знайдено або вже є стандартним.";
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile AvatarFile, string AvatarAction)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            switch (AvatarAction)
            {
                case "remove":
                    await RemoveExistingAvatar(user);
                    user.Image = DefaultAvatarPath;
                    break;

                case "default":
                    await RemoveExistingAvatar(user);
                    user.Image = DefaultAvatarPath;
                    break;

                case "nochange":
                    break;

                default:
                    if (AvatarFile != null && AvatarFile.Length > 0)
                    {
                        await RemoveExistingAvatar(user);

                        var uniqueFileName = Guid.NewGuid().ToString() + "_" + AvatarFile.FileName;
                        var newImagePath = Path.Combine("uploads", uniqueFileName);
                        var filePath = Path.Combine(_webHostEnvironment.WebRootPath, newImagePath);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await AvatarFile.CopyToAsync(stream);
                        }

                        user.Image = "~/" + newImagePath.Replace('\\', '/');
                    }
                    break;
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update the user.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }

        private async Task RemoveExistingAvatar(User user)
        {
            if (!string.IsNullOrEmpty(user.Image) && user.Image != DefaultAvatarPath)
            {
                var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, user.Image.TrimStart('~', '/'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
        }
    }
}
