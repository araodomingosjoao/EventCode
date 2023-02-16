using EventCode.Models.Entities;
using EventCode.Repository.Interfaces;
using EventCode.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace EventCode.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository) 
        {
            _repository = repository;
        }
        [HttpGet("users")]
        public IActionResult Get()
        {
            var users = _repository.Get();
            return users == null ? NotFound("Sem usuario cadastrado") : Ok(users);
        }
        [HttpGet("user/{id}")]
        public IActionResult Get(Guid id)
        {
            var user = _repository.GetById(id);
            return user == null ? NotFound("Usuario não encontrado") : Ok(user);
        }
        [HttpPost("user")]
        public IActionResult Post(User user)
        {
            _repository.Create(user);

            QRCoderService qrCoderService = new QRCoderService();
            Bitmap qrCodeImage = qrCoderService.Generator("https://localhost:44355/user/", user.Id);

            // Converta o objeto Bitmap em um objeto Stream
            MemoryStream ms = new MemoryStream();
            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;

            return _repository.SaveChanges()
                ? Ok(ms)
                : BadRequest("Erro ao cadastrar");
        }
    }
}
