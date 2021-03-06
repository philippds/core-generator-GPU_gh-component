﻿using System;
using System.Drawing;
using Grasshopper.Kernel;


namespace core_generator
{
    public class core_generator_info : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                // Return a 24x24 pixel bitmap to represent this GHA library.
                // return core_generator.Properties.Resources.os_reading_component;
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("F8F6DD70-03C1-43A1-AA25-1CF7C1CF4EB1"); // Tools -> Create Guid 5.
            }
        }
        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "Philipp Siedler";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "p.d.siedler@gmail.com";
            }
        }
    }
}
