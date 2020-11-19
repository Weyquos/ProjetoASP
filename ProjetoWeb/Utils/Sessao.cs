﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWeb.Utils
{
    public class Sessao
    {
        private readonly IHttpContextAccessor _http;
        public Sessao(IHttpContextAccessor http) => _http = http;
        private const string CARRINHO_ID = "CARRINHO_ID";
        public string BuscarCarrinhoId()
        {
            if(_http.HttpContext.Session.GetString(CARRINHO_ID) == null)
            {
                _http.HttpContext.Session.SetString(CARRINHO_ID, Guid.NewGuid().ToString());
            }
            return _http.HttpContext.Session.GetString(CARRINHO_ID);
        }
    }
}
