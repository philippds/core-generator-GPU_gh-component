﻿using System;
using System.Timers;
using System.Collections.Generic;
using Grasshopper.Kernel;
using System.Globalization;
using Rhino.Geometry;
using System.Linq;
using Grasshopper;

namespace core_generator
{
    public class core_generator_comp : GH_Component
    {
        GH_Document GrasshopperDocument;
        IGH_Component Component;
        
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public core_generator_comp(): base("core_generator_GPU", "", "", "PhilsComps", "Subcategory")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("skin_width", "skin_width", "skin_width", GH_ParamAccess.item, 20);
            pManager.AddIntegerParameter("skin_height", "skin_height", "skin_height", GH_ParamAccess.item, 20);

            pManager.AddIntegerParameter("core_min_width", "core_min_width", "core_min_width", GH_ParamAccess.item, 5);
            pManager.AddIntegerParameter("core_min_height", "core_min_height", "core_min_height", GH_ParamAccess.item, 5);

            pManager.AddNumberParameter("efficiency", "efficiency", "value 0.0 - 1.0", GH_ParamAccess.item, 0.15);

            pManager.AddNumberParameter("deviation", "deviation", "deviation", GH_ParamAccess.item, 0.0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddCurveParameter("skin", "skin", "skin", GH_ParamAccess.item);
            pManager.AddCurveParameter("cores", "cores", "cores", GH_ParamAccess.list);
            pManager.AddPointParameter("grid_pts", "grid_pts", "grid_pts", GH_ParamAccess.list);
            pManager.AddIntegerParameter("grid_val", "grid_val", "grid_val", GH_ParamAccess.tree);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            int skin_width = 0;
            int skin_height = 0;
            int core_min_width = 0;
            int core_min_height = 0;
            double efficiency = 0;
            double deviation = 0.0;

            DA.GetData(0, ref skin_width);
            DA.GetData(1, ref skin_height);
            DA.GetData(2, ref core_min_width);
            DA.GetData(3, ref core_min_height);
            DA.GetData(4, ref efficiency);
            DA.GetData(5, ref deviation);

            generate_tower gt = new generate_tower(ref skin_width, ref skin_height, ref core_min_width, ref core_min_height, ref efficiency, ref deviation);

            DA.SetData(0, gt.skin);
            DA.SetDataList(1, gt.cores);
            DA.SetDataList(2, gt.grid_pts);
            DA.SetDataTree(3, gt.grid_val);
        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                // return core_generator.Properties.Resources.os_reading_component;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("F8F6DD70-03C1-43A1-AA25-1CF7C1CF4EB1"); }
        }
        
    }
}
