using System;
using AcadControl.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcadControl.Controllers
{
    public abstract class ApplicationController
    {
        protected Entities db()
        {
            return new Entities();
        }
    }
}