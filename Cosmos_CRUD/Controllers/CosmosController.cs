﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmos_CRUD.DataAccess;
using Cosmos_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cosmos_CRUD.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class CosmosController : ControllerBase
    {
        /// <summary>
        /// </summary>
        ICosmosDataAdapter _adapter;
        public CosmosController(ICosmosDataAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET: api/Cosmos/5
        [HttpGet("createdb")]
        public async Task<IActionResult> CreateDatabase()
        {
            var result = await _adapter.CreateDatabase("test-db");
            return Ok(result);
        }

        [HttpGet("createcollection")]
        public async Task<IActionResult> CreateCollection()
        {
            var result = await _adapter.CreateCollection("test-db", "test-collection");
            return Ok(result);
        }

        [HttpPost("createdocument")]
        public async Task<IActionResult> CreateDocument([FromBody] UserInfo user)
        {
            var result = await _adapter.CreateDocument("test-db", "test-collection", user);
            return Ok(result);
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await _adapter.GetData("test-db", "test-collection");
            return Ok(result);
        }

        // POST: api/Cosmos
        [HttpPost("save/{id}")]
        public async Task<IActionResult> Post([FromBody] string firstname, [FromRoute]  string id, string dbname= "test-db",string name="test-collection")
        {
            var result = await _adapter.UpsertUserAsync(firstname, id, dbname,name);
            return Ok();
        }

        // PUT: api/Cosmos/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _adapter.DeleteUserAsync("test-db", "test-collection", id);
            return Ok(result);
        }
    }
}
