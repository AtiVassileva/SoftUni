﻿using System;
using Logger.Models.Contracts;
using Logger.Models.Layouts;

namespace Logger.Factories
{
    public class LayoutFactory
    {
        public ILayout ProduceLayout(string type)
        {
            ILayout layout;

            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else if (type == "JsonLayout")
            {
                layout = new JsonLayout();
            }
            else if (type == "ErrorLayout")
            {
                layout = new ErrorLayout();
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }

            return layout;
        }
    }
}
