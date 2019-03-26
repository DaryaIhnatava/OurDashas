// <copyright file="ShapeController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
namespace Jewelry.Web.Controllers
{
    #region Usings
    using Jewelry.Business.ShapeService;
    using Jewelry.Database.Data;
    using Microsoft.AspNetCore.Mvc;
    #endregion

    /// <summary>
    /// Shape Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class ShapeController : Controller
    {
        /// <summary>
        /// The shape service
        /// </summary>
        private readonly IShapeService shapeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeController"/> class.
        /// </summary>
        /// <param name="shapeService">The shape service.</param>
        public ShapeController(IShapeService shapeService)
        {
            this.shapeService = shapeService;
        }

        /// <summary>
        /// Inserts shape.
        /// </summary>
        /// <returns>View of inserting</returns>
        [HttpGet]
        public IActionResult Insert()
        {
            return this.View();
        }

        /// <summary>
        /// Inserts the specified shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        [HttpPost]
        public void Insert(Shape shape)
        {
            this.shapeService.InsertShape(shape);
        }
    }
}