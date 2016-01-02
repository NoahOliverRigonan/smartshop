﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace VideokeRental.Controllers
{
    public class ApiProductController : ApiController
    {
        private Data.videokerentalDataContext db = new Data.videokerentalDataContext();

        // list
        [Route("api/product/list")]
        public List<Models.tblProduct> Get()
        {

            var products = from d in db.tblProducts
                           select new Models.tblProduct
                           {
                               Id = d.Id,
                               ProductNumber = d.ProductNumber,
                               ProductName = d.ProductName,
                               ProductDescription = d.ProductDescription
                           };
            return products.ToList();
        }

        // add
        [Route("api/product/add")]
        public int Post(Models.tblProduct product)
        {

            try
            {
                Data.tblProduct newProduct = new Data.tblProduct();

                newProduct.ProductNumber = product.ProductNumber;
                newProduct.ProductName = product.ProductName;
                newProduct.ProductDescription = product.ProductDescription;

                db.tblProducts.InsertOnSubmit(newProduct);
                db.SubmitChanges();

                return newProduct.Id;
            }
            catch
            {
                return 0;
            }
        }

        // update
        [Route("api/updateProduct/{id}")]
        public HttpResponseMessage Put(String id, Models.tblProduct product)
        {
            try
            {
                var productId = Convert.ToInt32(id);
                var products = from d in db.tblProducts where d.Id == productId select d;

                if (products.Any())
                {
                    var updateProduct = products.FirstOrDefault();

                    updateProduct.ProductNumber = product.ProductNumber;
                    updateProduct.ProductName = product.ProductName;
                    updateProduct.ProductDescription = product.ProductDescription;

                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }

                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // delete product
        [Route("api/deleteProduct/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var productId = Convert.ToInt32(id);
                var products = from d in db.tblProducts where d.Id == productId select d;

                if (products.Any())
                {
                    db.tblProducts.DeleteOnSubmit(products.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}