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
        private readonly IConfiguration _configuration;

        public UserController(IUserRepository repository, IConfiguration configuration) 
        {
            _repository = repository;
            _configuration = configuration;
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
            var user_url = _configuration.GetValue<string>("APP:APP_URL") + user.Id;
            EmailService email = new EmailService("teste@antonioyosica.com", "Teste#1", "smtp.titan.email", 587);
            var e = email.Send("hernanysimao123@gmail.com", "Confirme a sua Presença", user_url);

            QRCoderService qrCoderService = new QRCoderService();
            Bitmap qrCodeImage = qrCoderService.Generator(_configuration.GetValue<string>("APP:APP_URL"), user.Id);

            //// Converta o objeto Bitmap em um objeto Stream
            var ms = qrCoderService.ToStream(qrCodeImage);

            return _repository.SaveChanges()
                ? Ok(ms)
                : BadRequest("Erro ao cadastrar");
        }
    }
}
